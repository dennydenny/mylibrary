using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View("InProgress");
        }

        public ActionResult Top10()
        {
            return View("InProgress");
        }

        public ActionResult StatByDay()
        {
            return View("InProgress");
        }

        public ActionResult InProgress()
        {
            return View();
        }
    }
}