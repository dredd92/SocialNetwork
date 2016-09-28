using System.Web.Helpers;
using SocialNetwork.DI;

namespace SocialNetwork.PL.WebApp.Models
{
    public static class Auth
    {
        public static bool CanLogIn(string username, string password)
        {
            var user = DependencyResolver.UserLogic.Get(username);

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
            var admin = DependencyResolver.AdminLogic.GetAdminByUsername(username);
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