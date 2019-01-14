using M183.Models;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace M183.Controllers
{
    public class SMSController : Controller
    {
        // GET: SMS
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CBUserModel model)
        {
            //string username = Request["username"];
            if (model.UserName == "burkarty" && model.Password == "123456")
            {
                //toked could also generated randomly, used for login
                string token = "1234";
                string i = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"];
                //send sms to the number mentioned in to
                var results = SMS.Send(new SMS.SMSRequest
                {
                    from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                    to = "41******** ",
                    text = token
                });
               return RedirectToAction("TokenLogin");
            }
            else
            {
                ViewBag.NotValidUser = "Wrong credentials";

            }

            return View("Index");

        }
        public ActionResult TokenLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TokenLogin(string model)
        {
            var token = Request["token"];
            if (token=="1234")
            {
                return RedirectToAction("UserLandingView", "Home");
            }
            else
            {
                ViewBag.NotValidUser = "Wrong Token";
                return View("Index");
            }

        }
    }
}