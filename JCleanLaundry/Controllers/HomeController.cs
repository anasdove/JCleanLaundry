using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Paket()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}