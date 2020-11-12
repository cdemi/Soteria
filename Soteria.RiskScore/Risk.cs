using System;
using System.Collections.Generic;
using System.Text;

namespace Soteria.RiskScore
{
    public static class Reason
    {
        public const string PasswordBreached = "PASSWORD_BREACHED";
        public const string IpAnonymizer = "IP_ANONYMIZER";
        public const string DifferentAS = "DIFFERENT_AS";
        public const string DifferentCountry = "DIFFERENT_COUNTRY";
        public const string DifferentContinent = "DIFFERENT_CONTINENT";
        public const string HostingProvider = "HOSTING_PROVIDER";
        public const string NoHistoricalData = "NO_HISTORICAL_DATA";
        public const string ImpossibleTravel = "IMPOSSIBLE_TRAVEL";
    }
    public class Risk
    {
        public float Score { get; set; }
        public List<string> Reasons { get; set; } = new List<string>();
    }
}
