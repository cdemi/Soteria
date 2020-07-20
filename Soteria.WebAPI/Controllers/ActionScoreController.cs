using Microsoft.AspNetCore.Mvc;
using Soteria.RiskScore;
using Soteria.WebAPI.Models;
using System.Threading.Tasks;

namespace Soteria.WebAPI.Controllers
{
    public class ActionScoreController : Controller
    {
        private readonly RiskCalculator riskScoreCalculator;

        public ActionScoreController(RiskCalculator riskScoreCalculator)
        {
            this.riskScoreCalculator = riskScoreCalculator;
        }

        [HttpPost("/score")]
        public async Task<IActionResult> Score([FromBody]ActionRequest actionRequest)
        {
            await riskScoreCalculator.Calculate(new RiskScore.Action
            {
                IP = actionRequest.IP,
                Password = actionRequest.Password,
                UserAgent = actionRequest.UserAgent,
                Username = actionRequest.Username
            });
            return Ok();
        }
    }
}
