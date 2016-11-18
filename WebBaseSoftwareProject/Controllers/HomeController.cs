﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WebBaseSoftwareProject.Models;
using System.IO;

namespace WebBaseSoftwareProject.Controllers
{
    public class HomeController : Controller
    {
        DBFilter dbfilter = new DBFilter();
        User testUser = new User() { UserName = "Test", Password = "password" };

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, User user)
        {

            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    dbfilter.StoreImage(file, user.ID);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Upload(User user)
        {
            return View(user);
        }
        [HttpGet]
        public ActionResult Download(User user)
        {
            return View(user);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            ViewResult result = View(u);
            return result;
        }

        [HttpPost]
        public ActionResult LogIn(User u)
        {
            ViewResult result = null;
            bool isLoggedIn = dbfilter.Login(u);
            if (isLoggedIn)
            {
                u = dbfilter.FetchUser(u.UserName);
                result = View("Index", u);
            }
            else
            {
                ViewBag.error = "Invalid username or password";
                result = View();
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
        public ActionResult SignUp(User u, string checkword)
        {
            ViewResult result = null;
            bool signup = dbfilter.SignUp(u);
            if (u.Password.Equals(checkword))
            {
                if (signup)
                {
                    u = dbfilter.FetchUser(u.UserName);
                    result = View("Index", u);
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    result = View();
                }
            }
            else
            {
                ViewBag.error = "Password do not match";
                result = View();
            }
            return result;
        }
    }
}