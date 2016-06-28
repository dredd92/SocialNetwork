using SocialNetwork.Entities;

namespace SocialNetwork.Dal.Interfaces
{
    public interface IMessagesDao
    {
        void AddMessage(Message message);
    }
}