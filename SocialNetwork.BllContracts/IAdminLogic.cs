using SocialNetwork.Entities;

namespace SocialNetwork.BllContracts
{
    public interface IAdminLogic : ILogic<Admin>
    {
        Admin Get(string username);
    }
}