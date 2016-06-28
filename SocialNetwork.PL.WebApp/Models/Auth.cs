using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace SocialNetwork.PL.WebApp.Models
{
    public static class Auth
    {
        public static bool CanLogIn(string username, string password)
        {
            var user = Common.UserLogic.GetUserByName(username);
            
            if (user == null)
            {
                return false;
            }
            else
            {
                return Crypto.VerifyHashedPassword(user.Password, password);
            }
        }

        public static bool CanLogInAdmin(string username, string password)
        {
            var admin = Common.AdminLogic.GetAdminByUsername(username);
            if (admin == null)
            {
                return false;
            }
            else
            {
                return Crypto.VerifyHashedPassword(admin.Password, password);
            }
        }
    }
}