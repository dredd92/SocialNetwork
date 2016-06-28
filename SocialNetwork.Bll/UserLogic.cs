using SocialNetwork.Bll.Interfaces;
using SocialNetwork.Entities;
using System.Collections.Generic;
using System;

namespace SocialNetwork.Bll
{
    public class UserLogic : IUserLogic
    {
        public void AddFriendToUser(int userId, int friendId)
        {
            DaoKeeper.UserDao.AddFriendToUser(userId, friendId);
        }

        public void AddUser(User user)
        {
            DaoKeeper.UserDao.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return DaoKeeper.UserDao.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return DaoKeeper.UserDao.GetUserById(userId);
        }

        public User GetUserByName(string username)
        {
            return DaoKeeper.UserDao.GetUserByName(username);
        }

        public IEnumerable<User> GetUserBySearchData(SearchData data)
        {
            return DaoKeeper.UserDao.GetUserBySearchData(data);
        }

        public IEnumerable<User> GetUserFriends(User user)
        {
            return DaoKeeper.UserDao.GetUserFriends(user.Id);
        }

        public bool RemoveFriendFromUser(int userId, int friendId)
        {
            return DaoKeeper.UserDao.RemoveFriendFromUser(userId, friendId);
        }

        public bool RemoveUser(int userId)
        {
            return DaoKeeper.UserDao.RemoveUser(userId);
        }

        public bool UpdateUser(int oldUserId, User newUser)
        {
            return DaoKeeper.UserDao.UpdateUser(oldUserId, newUser);
        }
    }
}