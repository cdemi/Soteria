using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Mvc;
using Soteria.WebAPI.Models;
using System.Threading.Tasks;

namespace Soteria.WebAPI.Controllers
{
    public class ActionScoreController : Controller
    {
        private readonly WebServiceClient _maxMindClient;

        public ActionScoreController(WebServiceClient maxMindClient)
        {
            this._maxMindClient = maxMindClient;
        }

        [HttpPost("/score")]
        public async Task<IActionResult> Score([FromBody]ActionRequest actionRequest)
        {
            var ipInsights = await _maxMindClient.InsightsAsync(actionRequest.IP);
            return new OkObjectResult(ipInsights.City.Name);
        }
    }
}
