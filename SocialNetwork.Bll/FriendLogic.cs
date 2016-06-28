using SocialNetwork.Bll.Interfaces;
using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Bll
{
    public class FriendLogic : IFriendLogic
    {
        public void AddFriendToUser(int userId, int friendId)
        {
            DaoKeeper.FriendsDao.AddFriendToUser(userId, friendId);
        }

        public IEnumerable<User> GetFriendsOfUser(int userId)
        {
            return DaoKeeper.FriendsDao.GetFriendsOfUser(userId);
        }

        public bool RemoveFriendFromUser(int userId, int friendId)
        {
            return DaoKeeper.FriendsDao.RemoveFriendFromUser(userId, friendId);
        }
    }
}