using System;
using System.Collections.Generic;
using SocialNetwork.BllContracts;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao dao;

        public UserLogic(IUserDao dao)
        {
            this.dao = dao;
        }

        public bool Add(User value)
        {
            throw new NotImplementedException();
        }

        public bool AddFriend(int userId, int friendId)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(SearchData data)
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFriend(int userId, int friendId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, User newValue)
        {
            throw new NotImplementedException();
        }
    }
}