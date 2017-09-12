using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerParts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Computer Parts Company.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Computer Parts Contacts.";

            return View();
        }
    }
}