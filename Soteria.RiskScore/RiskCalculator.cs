using MaxMind.GeoIP2;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Soteria.Data;
using Soteria.HaveIBeenPwned;
using System;
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
            var haveIBeenPwnedSearch = _haveIBeenPwnedService.IsPasswordBreached(action.Password);
            var maxMindInsightsSearch = _maxMindClient.InsightsAsync(action.IP);
            var lastLoginSearch = _soteriaContext.LoginHistories.OrderByDescending(lh=>lh.DateTime).Where(lh => lh.Username.Equals(action.Username)).FirstOrDefaultAsync();


            var isPasswordBreached = await haveIBeenPwnedSearch;
            var maxMindInsights = await maxMindInsightsSearch;

            _soteriaContext.LoginHistories.Add(new LoginHistory
            {
                City = maxMindInsights.City.Name,
                DateTime = DateTime.Now,
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
                Country = maxMindInsights.Country.Name
            });

            await _soteriaContext.SaveChangesAsync();

            var lastLogin = await lastLoginSearch;

            float score = 0f;

            if (isPasswordBreached)
                score += 0.8f;

            if (maxMindInsights.Traits.IsAnonymous || maxMindInsights.Traits.IsAnonymousProxy || maxMindInsights.Traits.IsAnonymousVpn || maxMindInsights.Traits.IsHostingProvider || maxMindInsights.Traits.IsPublicProxy || maxMindInsights.Traits.IsTorExitNode)
                score += 0.7f;

            if (lastLogin != null)
            {
                if (lastLogin.AutonomousSystemNumber != maxMindInsights.Traits.AutonomousSystemNumber)
                    score += 0.4f;

            }
            else
            {
                score += 1f;
            }


            if (score > 1f)
                score = 1f;

            return new Risk
            {
                Score = score
            };
        }
    }
}
