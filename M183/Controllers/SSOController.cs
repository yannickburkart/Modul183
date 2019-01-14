using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using System.Net;
using System.Text;
using System.IO;
using M183.Models;

namespace M183.Controllers
{
    public class SSOController : Controller
    {
        // GET: SSO
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index(CBUserModel model)
        {
            if (model.UserName == "burkarty" && model.Password == "123456")
            {
                //login true
                return RedirectToAction("UserLandingView", "Home");

            }
            else
            {
                //login false
                ViewBag.NotValidUser = "Wrong credentials";

            }
            return View("Index");

        }
        public JsonResult SSOTokenSignin()
        {
            https://developers.goggle.com/api-client-library/dotnet/apis/oauth2/v2 
            var id_token = Request["idtoken"];
            var request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + id_token);
            var postData = "id_token=" + id_token;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream=request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return Json(responseString);
        }
    }
}