using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.MsSqlDal
{
    public class UserDao : IUserDao
    {
        public bool Add(User value)
        {
            throw new NotImplementedException();
        }


        public User Get(string username)
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

        bool AddFriend(int userId, int friendId)
        {
            throw new NotImplementedException();
        }
    }
}