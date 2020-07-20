using MaxMind.GeoIP2;
using Newtonsoft.Json;
using Soteria.Data;
using System;
using System.Threading.Tasks;

namespace Soteria.RiskScore
{
    public class RiskCalculator
    {
        private readonly WebServiceClient _maxMindClient;
        private readonly SoteriaContext _soteriaContext;

        public RiskCalculator(WebServiceClient maxMindClient, SoteriaContext soteriaContext)
        {
            this._maxMindClient = maxMindClient;
            this._soteriaContext = soteriaContext;
        }

        public async Task<Risk> Calculate(Action action)
        {
            var maxMindInsights = await _maxMindClient.InsightsAsync(action.IP);
            return new Risk
            {
                Score = 0.4f
            };
        }
    }
}
