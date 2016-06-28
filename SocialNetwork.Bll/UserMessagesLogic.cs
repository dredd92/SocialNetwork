using SocialNetwork.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class UserMessagesLogic : IUserMessagesLogic
    {
        public IEnumerable<Message> GetUnreadDialogMessages(int userId, int secondPersonId)
        {
            return DaoKeeper.UserMessagesDao.GetUnreadDialogMessages(userId, secondPersonId);
        }

        public IEnumerable<Dialog> GetUserDialogs(int userId)
        {
            return DaoKeeper.UserMessagesDao.GetUserDialogs(userId);
        }

        public IEnumerable<Dialog> GetUserDialogsUnread(int userId)
        {
            return DaoKeeper.UserMessagesDao.GetUserDialogsUnread(userId);
        }
    }
}
