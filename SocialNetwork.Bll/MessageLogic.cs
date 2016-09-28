using System;
using SocialNetwork.BllContracts;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageDao dao;

        public MessageLogic(IMessageDao dao)
        {
            this.dao = dao;
        }

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