using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBaseSoftwareProject.Controllers
{
    public class HomeController : Controller
    {
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
            if (!ModelState.IsValid)
            {
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
            using (hashtag_javaContext con = new hashtag_javaContext())
            {
                User user = new User() { UserName = u.UserName, Password = u.Password };
                con.Users.Add(u);
            }
            if (ModelState.IsValid)
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