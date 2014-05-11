using MvcHomework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomework2.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        public ActionResult Index()
        {
            var data = from c in RepositoryHelper.GetV_CustomerDetailSumRepository().All()
                       select new CustomerVM
                       {
                           Id = c.Id,
                           CustomerName = c.CustomerName,
                           NumOfBanks = (int)c.NumOfBanks,
                           NumOfContacts = (int)c.NumOfContacts
                       };
            return View(data);
        }
    }
}