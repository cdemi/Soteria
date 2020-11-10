using System;

namespace Soteria.Data
{
    public class LoginHistory
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Username { get; set; }
        public string UserAgent { get; set; }
        public string IP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public double? StaticIPScore { get; set; }
        public string? Organization { get; set; }
        public string? Isp { get; set; }
        public bool IsHostingProvider { get; set; }
        public bool IsSatelliteProvider { get; set; }
        public bool IsPublicProxy { get; set; }
        public bool IsLegitimateProxy { get; set; }
        public bool IsAnonymousVpn { get; set; }
        public bool IsAnonymousProxy { get; set; }
        public bool IsAnonymous { get; set; }
        public string? Domain { get; set; }
        public string? ConnectionType { get; set; }
        public string? AutonomousSystemOrganization { get; set; }
        public long? AutonomousSystemNumber { get; set; }
        public string? UserType { get; set; }
        public bool IsTorExitNode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }
}
