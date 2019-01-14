using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Authenticator;
using M183.Models;

namespace M183.Controllers
{
    public class GAuthController : Controller
    {
        // GET: GAuth
        public ActionResult Index()
        {
            return View();
        }
        //two factor authentication
        public ActionResult SetupAuthentication()
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            //yannickburkartyannick is my secret key
            var setupInfo = tfa.GenerateSetupCode("RollandRoll GMBH", "********@gmail.com", "*********", 300, 300);
            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
            string manualEntrySetupCode = setupInfo.ManualEntryKey;
            ViewBag.Message = "<h2>QR-Code:</h2><br><br><img src = '" + qrCodeImageUrl + "'/> <br><br><h2>Token for manual entry</h2> <br>" + manualEntrySetupCode;
            return View();
        }
        [HttpPost]
        public ActionResult Login(CBUserModel model)
        {
           
            if (model.UserName == "burkarty" && model.Password == "123456")
            {
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                //secret key and token
                bool isCorrectPIN = tfa.ValidateTwoFactorPIN("***********", model.Token);

                if (isCorrectPIN)
                {
                    ViewBag.Message = "Login and Token correct";
                    return RedirectToAction("UserLandingView", "Home");
                }
                else
                {
                    ViewBag.Message = "Wrong credentials and token";
                }
            }
            else
            {
                ViewBag.NotValidUser = "Wrong Credentials";
            }
            return View("Index");
        }
    }
}