using GeoCoordinatePortable;
using MaxMind.GeoIP2;
using Microsoft.EntityFrameworkCore;
using Soteria.Data;
using Soteria.HaveIBeenPwned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soteria.RiskScore
{
    public class RiskCalculator
    {
        private readonly WebServiceClient _maxMindClient;
        private readonly SoteriaContext _soteriaContext;
        private readonly IHaveIBeenPwnedService _haveIBeenPwnedService;

        public RiskCalculator(WebServiceClient maxMindClient, SoteriaContext soteriaContext, IHaveIBeenPwnedService haveIBeenPwnedService)
        {
            this._maxMindClient = maxMindClient;
            this._soteriaContext = soteriaContext;
            this._haveIBeenPwnedService = haveIBeenPwnedService;
        }

        public async Task<Risk> Calculate(Action action)
        {
            var haveIBeenPwnedSearch = _haveIBeenPwnedService.IsPasswordBreachedAsync(action.Password);
            var maxMindInsightsSearch = _maxMindClient.InsightsAsync(action.IP);
            var lastLoginSearch = _soteriaContext.LoginHistories.OrderByDescending(lh => lh.DateTime).Where(lh => lh.Username.Equals(action.Username)).FirstOrDefaultAsync();


            var maxMindInsights = await maxMindInsightsSearch;

            _soteriaContext.LoginHistories.Add(new LoginHistory
            {
                City = maxMindInsights.City.Name,
                DateTime = DateTime.UtcNow,
                IP = action.IP,
                UserAgent = action.UserAgent,
                Username = action.Username,
                AutonomousSystemNumber = maxMindInsights.Traits.AutonomousSystemNumber,
                AutonomousSystemOrganization = maxMindInsights.Traits.AutonomousSystemOrganization,
                ConnectionType = maxMindInsights.Traits.ConnectionType,
                Domain = maxMindInsights.Traits.Domain,
                IsAnonymous = maxMindInsights.Traits.IsAnonymous,
                IsAnonymousProxy = maxMindInsights.Traits.IsAnonymousProxy,
                IsAnonymousVpn = maxMindInsights.Traits.IsAnonymousVpn,
                IsHostingProvider = maxMindInsights.Traits.IsHostingProvider,
                IsLegitimateProxy = maxMindInsights.Traits.IsLegitimateProxy,
                Isp = maxMindInsights.Traits.Isp,
                IsPublicProxy = maxMindInsights.Traits.IsPublicProxy,
                IsSatelliteProvider = maxMindInsights.Traits.IsSatelliteProvider,
                IsTorExitNode = maxMindInsights.Traits.IsTorExitNode,
                Organization = maxMindInsights.Traits.Organization,
                StaticIPScore = maxMindInsights.Traits.StaticIPScore,
                UserType = maxMindInsights.Traits.UserType,
                Continent = maxMindInsights.Continent.Name,
                Country = maxMindInsights.Country.Name,
                Latitude = maxMindInsights.Location.Latitude,
                Longitude = maxMindInsights.Location.Longitude
            });

            await _soteriaContext.SaveChangesAsync();

            var lastLogin = await lastLoginSearch;
            var isPasswordBreached = await haveIBeenPwnedSearch;

            float score = 0f;
            List<string> scoreReasons = new List<string>();

            if (isPasswordBreached)
            {
                score += 0.9f;
                scoreReasons.Add(Reason.PasswordBreached);
            }

            if (maxMindInsights.Traits.IsAnonymous || maxMindInsights.Traits.IsAnonymousProxy || maxMindInsights.Traits.IsAnonymousVpn || maxMindInsights.Traits.IsPublicProxy || maxMindInsights.Traits.IsTorExitNode)
            {
                score += 0.7f;
                scoreReasons.Add(Reason.IpAnonymizer);
            }

            if (maxMindInsights.Traits.IsHostingProvider)
            {
                score += 0.8f;
                scoreReasons.Add(Reason.HostingProvider);
            }

            if (lastLogin != null)
            {
                if (lastLogin.AutonomousSystemNumber != maxMindInsights.Traits.AutonomousSystemNumber)
                {
                    score += 0.2f;
                    scoreReasons.Add(Reason.DifferentAS);
                }

                if (!lastLogin.Country.Equals(maxMindInsights.Country.Name))
                {
                    score += 0.3f;
                    scoreReasons.Add(Reason.DifferentCountry);
                }

                if (!lastLogin.Continent.Equals(maxMindInsights.Continent.Name))
                {
                    score += 0.4f;
                    scoreReasons.Add(Reason.DifferentContinent);
                }

                var daysSinceLastLogin = (DateTime.UtcNow - lastLogin.DateTime).TotalDays;
                score += 0.0015f * (int)daysSinceLastLogin;

                if (lastLogin.Latitude.HasValue && lastLogin.Longitude.HasValue && maxMindInsights.Location.Latitude.HasValue && maxMindInsights.Location.Longitude.HasValue)
                {
                    var lastLoginLocation = new GeoCoordinate(lastLogin.Latitude.Value, lastLogin.Longitude.Value);
                    var currentLoginLocation = new GeoCoordinate(maxMindInsights.Location.Latitude.Value, maxMindInsights.Location.Longitude.Value);

                    var distanceBetweenLocations = lastLoginLocation.GetDistanceTo(currentLoginLocation);

                    if (distanceBetweenLocations > 100000)
                    {
                        var secondsBetweenLogins = (DateTime.UtcNow - lastLogin.DateTime).TotalSeconds;

                        var averageSpeed = distanceBetweenLocations / secondsBetweenLogins;
                        const double maximumAllowedSpeed = 278; // Travel of over 278 meters per second is considered impossible

                        if (averageSpeed > maximumAllowedSpeed)
                        {
                            score += 0.7f;
                            scoreReasons.Add(Reason.ImpossibleTravel);
                        }
                    }
                }
            }
            else
            {
                score += 1f;
                scoreReasons.Add(Reason.NoHistoricalData);
            }


            if (score > 1f)
                score = 1f;

            return new Risk
            {
                Score = score,
                Reasons = scoreReasons
            };
        }
    }
}
