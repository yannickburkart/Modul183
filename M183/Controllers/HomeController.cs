using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M183.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Phishing()
        {
            return View();
        }
        public ActionResult Frame()
        {
            return View();
        }
        public ActionResult UserLandingView(string pId)
        {
            string i = pId;
            return View();
        }
        public ActionResult Https()
        {
            return View();
        }


    }
}