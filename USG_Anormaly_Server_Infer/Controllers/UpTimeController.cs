using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace USG_Anormaly_Server_Infer.Controllers
{
    public class UpTimeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var a = new
            {
                startDate = WebApiConfig.startDate,
                curDate = DateTime.Now,
                upTime = DateTime.Now.Subtract(WebApiConfig.startDate)
            };
            return Request.CreateResponse(HttpStatusCode.OK, a);
        }
    }
}
