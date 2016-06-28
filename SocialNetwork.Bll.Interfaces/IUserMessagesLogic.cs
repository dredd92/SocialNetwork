using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Bll.Interfaces
{
    public interface IUserMessagesLogic
    {
        IEnumerable<Dialog> GetUserDialogs(int userId);

        IEnumerable<Dialog> GetUserDialogsUnread(int userId);

        IEnumerable<Message> GetUnreadDialogMessages(int userId, int secondPersonId);
    }
}
