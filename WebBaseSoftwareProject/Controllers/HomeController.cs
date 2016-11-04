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
        public ActionResult Index(User u)
        {
            
                return View(u);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User u)
        {
            ViewResult result = null;
            using (hashtag_javaContext con = new hashtag_javaContext())
            {
                con.Users.Add(u);
            }
            if (ModelState.IsValid)
            {
                result = View("Index", u);
            }
            else
            {
                ViewBag.error = "Invalid user";
                result = View();
            }
            return result;
        }
    }
}