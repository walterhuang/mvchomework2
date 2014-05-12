using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomework2.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult JavascriptTest()
        {
            return JavaScript("alert('ok')");
        }
        public ActionResult FileTest()
        {
            return File(Server.MapPath(@"~\Content\N000381297_t_06.jpg"), "image/jpeg");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}