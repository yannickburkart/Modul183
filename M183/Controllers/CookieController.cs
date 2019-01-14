using M183.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M183.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CookieLogin model)
        {
            //string username = Request["username"];
            if (model.UserName == "burkarty" && model.Password == "123456")
            {

                Response.Cookies.Add(CreateCookie(false));
            }
            else
            {
                ViewBag.NotValidUser = "Wrong credentials";

            }

            return View("Logedin");

        }
        private HttpCookie CreateCookie(bool delete=false)
        {
            HttpCookie cookie = new HttpCookie("testcookie")
            {
                Value = "hello",
                Expires = delete ? DateTime.Now.AddHours(-2) : DateTime.Now.AddHours(2)
            };
            return cookie;
        }
        public  ActionResult Logedin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Response.Cookies.Add(CreateCookie(true));

            return View("Index");
        }

    }
}