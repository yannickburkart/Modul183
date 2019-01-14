using M183.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M183.Controllers
{
    public class SQL_XSSController : Controller
    {
        // GET: SQL_XSS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(CBUserModel model)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\burkarty\Documents\SQL_XSS_INJECTION.mdf;Integrated Security=True;Connect Timeout=30";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT [Id], [username], [password] FROM [dbo].[User] WHERE [username] = '"+model.UserName+"' AND [password] = '"+model.Password+"'";
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ViewBag.Message = "success";
                while (reader.Read())
                {
                    ViewBag.Message += reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }
            return View("index");
            
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoFeedback()
        {
            var feedback = Request["feedback"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\burkarty\Documents\SQL_XSS_INJECTION.mdf;Integrated Security=True;Connect Timeout=30";
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "INSER INTO [dbo].[Feedback] SET [feedback] = '"+feedback+"'";
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ViewBag.Message = "success";
                while (reader.Read())
                {
                    ViewBag.Message += reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }
            

            return View();
        }
    }
}