using System.Collections.Generic;
using SocialNetwork.Entities;

namespace SocialNetwork.DalContracts
{
    public interface IUserDao : ICrud<User>
    {
        IEnumerable<User> GetAll();

        IEnumerable<User> Get(SearchData data);

        User Get(string username);

        bool RemoveFriend(int userId, int friendId);

        bool AddFriend(int userId, int friendId);
    }
}