using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBaseSoftwareProject
{
    public partial class User
    {
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