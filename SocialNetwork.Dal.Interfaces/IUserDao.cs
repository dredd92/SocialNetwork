using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Dal.Interfaces
{
    public interface IUserDao
    {
        void AddUser(User user);

        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetUserBySearchData(SearchData data);

        bool RemoveUser(int userId);

        bool UpdateUser(int userId, User newUser);

        User GetUserByName(string username);

        User GetUserById(int userId);

        IEnumerable<User> GetUserFriends(int userId);

        bool RemoveFriendFromUser(int userId, int friendId);

        void AddFriendToUser(int userId, int friendId);
    }
}