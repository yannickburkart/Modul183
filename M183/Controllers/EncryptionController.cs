using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M183.Controllers
{
    public class EncryptionController : Controller
    {
        // GET: Encryption
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cesar()
        {
            return View();
        }
        public ActionResult Vigenere()
        {
            return View();
        }
        public ActionResult OneTimePad()
        {
            return View();
        }
    }
}