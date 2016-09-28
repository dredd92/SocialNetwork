using System.Collections.Generic;
using SocialNetwork.Entities;

namespace SocialNetwork.BllContracts
{
    public interface IUserLogic : ILogic<User>
    {
        User Get(string username);

        IEnumerable<User> GetAll();

        bool RemoveFriend(int userId, int friendId);

        bool AddFriend(int userId, int friendId);

        IEnumerable<User> Get(SearchData data);
    }
}