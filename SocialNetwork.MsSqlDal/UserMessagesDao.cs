using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.MsSqlDal
{
    public class UserMessagesDao : IUserMessagesDao
    {
        public IEnumerable<Message> GetUnreadDialogMessages(int firstPersonId, int secondPersonId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dialog> GetUserDialogs(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dialog> GetUserDialogsUnread(int id)
        {
            throw new NotImplementedException();
        }
    }
}