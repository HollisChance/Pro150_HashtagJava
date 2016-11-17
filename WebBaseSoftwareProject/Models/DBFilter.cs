using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.IO;

namespace WebBaseSoftwareProject.Models
{
    public class DBFilter
    {
        public DBFilter()
        {
        }

        public User FetchUser(string userName)
        {
            User user = null;
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                user = con.Users.Where(u => u.UserName == userName).FirstOrDefault();
            }
            return user;
        }

        public bool Login(User passedUser)
        {
            bool isLoggedIn = false;
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                User user = con.Users.Where(u => u.UserName == passedUser.UserName).FirstOrDefault();
                if(user != null)
                {
                    if (user.Password == passedUser.Password)
                    {
                        passedUser = user;
                        isLoggedIn = true;
                    }
                    else
                    {
                        passedUser.Password = string.Empty;
                    }
                }
            }
            return isLoggedIn;
        }

        public bool SignUp(User passedUser)
        {
            bool accountCreated = false;
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                User user = con.Users.Where(u => u.UserName == passedUser.UserName).FirstOrDefault();
                if(user == null)
                {
                    con.Users.Add(passedUser);
                    con.SaveChanges();
                    accountCreated = true;
                }
            }
            return accountCreated;
        }

        public bool StoreImage(HttpPostedFileBase file, int userID)
        {
            Image img = new Image();
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            img.StoredImg = target.ToArray();
            img.UserID = userID;
            bool imgStored = false;
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                con.Images.Add(img);
                con.SaveChanges();
                imgStored = true;
            }
            return imgStored;
        }
    }
}