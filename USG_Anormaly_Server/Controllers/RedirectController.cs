using Microsoft.AspNetCore.Mvc;

namespace USG_Anormaly_Server.Controllers
{
    
    public class RedirectController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
            //http://localhost/swagger/index.html
            //https://localhost:7033/swagger/index.html
            return Redirect($"{Request.Scheme}://{requestHeaders["Host"]}/swagger/index.html");
        }
    }
}
