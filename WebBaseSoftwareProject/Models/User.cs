using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBaseSoftwareProject.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        // will this work?????

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj.GetType() == typeof(User))
            {
                User u = obj as User;
                if (UserName == u.UserName && Password == u.Password)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}