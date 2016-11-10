using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WebBaseSoftwareProject.Models;

namespace WebBaseSoftwareProject.Controllers
{
    public class HomeController : Controller
    {
        DBFilter dbfilter = new DBFilter();
        User testUser = new User() { UserName = "Test", Password = "password" };
        // GET: Home
        public ActionResult Index()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            ViewResult result = View(u);

            if (!ModelState.IsValid || !dbfilter.Login(u));
            {
                ViewBag.error = "Invalid username or password";
                result = View("LogIn", u);
            }   
            return result;
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult FailedLogin()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(User u)
        {
            ViewResult result = null;
            bool isLoggedIn = dbfilter.Login(u);
            if (isLoggedIn)
            {
                result = View("Index", u);
            }
            else
            {
                ViewBag.error = "Invalid username or password";
                result = View();
            }
            return result;
        }
    }
}