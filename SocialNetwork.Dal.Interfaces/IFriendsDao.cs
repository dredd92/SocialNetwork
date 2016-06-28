using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Dal.Interfaces
{
    public interface IFriendsDao
    {
        void AddFriendToUser(int userId, int friendId);

        IEnumerable<User> GetFriendsOfUser(int userId);

        bool RemoveFriendFromUser(int userId, int friendId);
    }
}