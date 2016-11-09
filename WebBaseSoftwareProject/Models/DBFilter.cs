using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace WebBaseSoftwareProject.Models
{
    public class DBFilter
    {
        public DBFilter()
        {

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
    }
}