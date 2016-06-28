using SocialNetwork.Bll;
using SocialNetwork.Bll.Interfaces;

namespace SocialNetwork.PL.WebApp
{
    public static class Common
    {
        public static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly IUserLogic UserLogic = new UserLogic();
        public static readonly IMessageLogic MessageLogic = new MessageLogic();
        public static readonly IUserMessagesLogic UserMessagesLogic = new UserMessagesLogic();
        public static readonly IAdminLogic AdminLogic = new AdminLogic();
    }
}