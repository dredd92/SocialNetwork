using SocialNetwork.Bll.Interfaces;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class MessageLogic : IMessageLogic
    {
        public void AddMessage(Message message)
        {
            DaoKeeper.MessageDao.AddMessage(message);
        }
    }
}