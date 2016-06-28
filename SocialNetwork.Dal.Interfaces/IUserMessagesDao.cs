using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Dal.Interfaces
{
    public interface IUserMessagesDao
    {
        IEnumerable<Dialog> GetUserDialogs(int userId);

        IEnumerable<Dialog> GetUserDialogsUnread(int id);

        IEnumerable<Message> GetUnreadDialogMessages(int firstPersonId, int secondPersonId);
    }
}
