using System.Web;
using System.Web.Mvc;

namespace USG_Anormaly_Inference_Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
