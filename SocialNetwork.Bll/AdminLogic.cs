using System;
using SocialNetwork.BllContracts;
using SocialNetwork.DalContracts;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class AdminLogic : IAdminLogic
    {
        private readonly IAdminDao dao;

        public AdminLogic(IAdminDao dao)
        {
            this.dao = dao;
        }

        public bool Add(Admin value)
        {
            throw new NotImplementedException();
        }

        public Admin Get(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Get(string username)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Admin newValue)
        {
            throw new NotImplementedException();
        }
    }
}