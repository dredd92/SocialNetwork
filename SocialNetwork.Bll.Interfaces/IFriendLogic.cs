using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Bll.Interfaces
{
    public interface IFriendLogic
    {
        void AddFriendToUser(int userId, int friendId);

        IEnumerable<User> GetFriendsOfUser(int userId);

        bool RemoveFriendFromUser(int userId, int friendId);
    }
}