using System.Collections.Generic;
using SocialNetwork.Entities;

namespace SocialNetwork.BllContracts
{
    public interface IUserMessageLogic
    {
        IEnumerable<Dialog> GetUserDialogs(int userId);

        IEnumerable<Dialog> GetUserDialogsUnread(int userId);

        IEnumerable<Message> GetUnreadDialogMessages(int userId, int secondPersonId);
    }
}