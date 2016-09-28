using System;
using System.Data;
using System.Data.SqlClient;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.MsSqlDal
{
    public class MessageDao : IMessageDao
    {
        public bool Add(Message value)
        {
            throw new NotImplementedException();
        }

        public Message Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Message newValue)
        {
            throw new NotImplementedException();
        }
    }
}