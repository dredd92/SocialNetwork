using System;
using System.Collections.Generic;
using SocialNetwork.BllContracts;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class UserMessageLogic : IUserMessageLogic
    {
        private readonly IUserMessagesDao dao;

        public UserMessageLogic(IUserMessagesDao dao)
        {
            this.dao = dao;
        }

        public IEnumerable<Message> GetUnreadDialogMessages(int userId, int secondPersonId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dialog> GetUserDialogs(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dialog> GetUserDialogsUnread(int userId)
        {
            throw new NotImplementedException();
        }
    }
}