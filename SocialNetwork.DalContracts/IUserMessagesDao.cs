using System.Collections.Generic;
using SocialNetwork.Entities;

namespace SocialNetwork.DalContracts
{
    public interface IUserMessagesDao
    {
        IEnumerable<Dialog> GetUserDialogs(int userId);

        IEnumerable<Dialog> GetUserDialogsUnread(int id);

        IEnumerable<Message> GetUnreadDialogMessages(int firstPersonId, int secondPersonId);
    }
}