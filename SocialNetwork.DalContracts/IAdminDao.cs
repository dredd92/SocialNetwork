using SocialNetwork.Entities;

namespace SocialNetwork.DalContracts
{
    public interface IAdminDao : ICrud<Admin>
    {
        Admin Get(string username);
    }
}