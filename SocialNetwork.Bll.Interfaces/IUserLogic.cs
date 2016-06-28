using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Bll.Interfaces
{
    public interface IUserLogic
    {
        User GetUserByName(string username);

        User GetUserById(int userId);

        void AddUser(User user);

        IEnumerable<User> GetAllUsers();

        bool RemoveUser(int userId);

        bool UpdateUser(int oldUserId, User newUser);

        bool RemoveFriendFromUser(int userId, int friendId);

        void AddFriendToUser(int userId, int friendId);

        IEnumerable<User> GetUserFriends(User user);

        IEnumerable<User> GetUserBySearchData(SearchData data);
    }
}