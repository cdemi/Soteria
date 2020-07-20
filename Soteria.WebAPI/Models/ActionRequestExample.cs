using Swashbuckle.AspNetCore.Filters;

namespace Soteria.WebAPI.Models
{
    public class ActionRequestExample : IExamplesProvider<ActionRequest>
    {
        ActionRequest IExamplesProvider<ActionRequest>.GetExamples()
        {
            return new ActionRequest
            {
                IP = "213.217.205.152",
                Username = "testUser",
                Password = "password",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36"
            };
        }
    }
}
