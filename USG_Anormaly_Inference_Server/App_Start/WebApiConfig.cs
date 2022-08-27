using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace USG_Anormaly_Inference_Server
{
    public static class WebApiConfig
    {
        public static DateTime startDate = DateTime.Now;
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            startDate = DateTime.Now;
            // Web API routes
            config.MapHttpAttributeRoutes();
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //        name: "Redirect",
            //        routeTemplate: "/",
            //        defaults: new { controller = "Redirect", action = "Get" }
            //    );
        }
    }
}
