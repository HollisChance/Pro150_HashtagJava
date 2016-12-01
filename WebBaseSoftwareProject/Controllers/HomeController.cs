using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WebBaseSoftwareProject.Models;
using System.IO;
using HollisCAsciiArtLib.Controller;
using HollisCAsciiArtLib.Model;

namespace WebBaseSoftwareProject.Controllers
{

    public class HomeController : Controller
    {
        User testUser = new User() { UserName = "Test", Password = "password" };
        DBFilter dbfilter = new DBFilter();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("LogIn");
        }

        [HttpPost]
        public FileResult Download(Image image)
        {
            //image.ReturnAscii(); Either transfer image to ascii for download or store ascii in DB
            byte[] file;
            file = dbfilter.GetText(image.ImgId);
            int userId = dbfilter.FetchUserIdByImgId(image.ImgId);
            string userName = dbfilter.FetchUserNameById(userId);
            string fileName =   userName + "-" + image.ImgId + ".txt";   
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, User user, ArtOptions settings = null)
        {
            ArtGenerator gen = new ArtGenerator();
            ImageFileIO IO = new ImageFileIO();
            //settings.DarkChar = Request["darkChar"];
            //settings.MedChar = Request["medChar"];
            //settings.LightChar = Request["lightChar"];
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] imageBytes = target.ToArray();
            

            System.Drawing.Image img = new System.Drawing.Bitmap(target);
            //System.Drawing.Image img = ImageFileIO.ImageFromFile(@"C:\Users\chance\Documents\Visual Studio 2015\ProjectsCourse-Web\WebSoftwareProject\Pro150_HashtagJava\WebBaseSoftwareProject\Images\java_logo6.jpg");
            //System.Drawing.Image newImg = ImageFileIO.ImageFromFile(file.FileName);

            if (img != null)
            {
                ViewBag.Art = gen.MakeArt(img, settings);
            }
            
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    dbfilter.StoreImage(ViewBag.art, user.ID);
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
            List<Image> images = dbfilter.FetchUserImages(user.ID);
            return View(images);
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