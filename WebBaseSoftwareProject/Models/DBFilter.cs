using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Text;

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

        public bool StoreImage(string ascii, int userID)
        {
            Image img = new Image();
            MemoryStream target = new MemoryStream();
            img.User_ID = userID;
            bool imgStored = false;
            img.StoredImg = Encoding.ASCII.GetBytes(ascii);
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                //img.ReturnAscii(); will transfer to ascii and store it to blob
                con.Images.Add(img);
                con.SaveChanges();
                imgStored = true;
            }
            return imgStored;
        }

        public void GetImageOrText(int ImgID)
        {
            byte[] file;
            
            using (hashtag_javaEntities con = new hashtag_javaEntities())
            {
                file = con.Images.Where(i => i.ImgId == ImgID).Single().StoredImg;

                /*To return Image
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(file)))
                {
                    image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
                }*/

                //To write byte[] to text file
                //File.WriteAllBytes("PlaceHolder", file);

            }
        }
    }
}