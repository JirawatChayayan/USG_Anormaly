using System.Web.Http;
using WebActivatorEx;
using USG_Anormaly_Server_Infer;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace USG_Anormaly_Server_Infer
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {

                        c.SingleApiVersion("v1", "USG_Anormaly_Server_Infer");
                    })
                .EnableSwaggerUi(c =>
                    {
                      
                    });
        }
    }
}
