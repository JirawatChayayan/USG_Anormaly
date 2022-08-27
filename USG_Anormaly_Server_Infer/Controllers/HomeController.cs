using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USG_Anormaly_Server_Infer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //return View();
            return Redirect(Request.Url.AbsoluteUri + "swagger");
        }
    }
}
