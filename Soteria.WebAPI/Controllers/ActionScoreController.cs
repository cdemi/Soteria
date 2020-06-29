using Microsoft.AspNetCore.Mvc;
using Soteria.WebAPI.Models;

namespace Soteria.WebAPI.Controllers
{
    public class ActionScoreController : Controller
    {
        [HttpPost("/score")]
        public IActionResult Score([FromBody]ActionRequest actionRequest)
        {
            return Ok();
        }
    }
}
