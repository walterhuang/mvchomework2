using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcHomework2.Controllers
{
    public class BaseController : Controller
    {
        public string MyProperty
        {
            get
            {
                return WebConfigurationManager.AppSettings["MyProperty"];
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
                //this.View(actionName).ExecuteResult(this.ControllerContext);
                 Redirect("/");
            else
                base.HandleUnknownAction(actionName);
        }
    }
}