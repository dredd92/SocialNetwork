using SocialNetwork.Dal.Interfaces;
using System.Configuration;

namespace SocialNetwork.Dal.Database
{
    public static class DaoKeeper
    {
        public static readonly IFriendsDao FriendsDao = new FriendDao(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        public static readonly IUserDao UserDao = new UserDao(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        public static readonly IUserMessagesDao UserMessagesDao = new UserMessagesDao(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    }
}