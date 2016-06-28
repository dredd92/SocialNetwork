using SocialNetwork.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;

namespace SocialNetwork.Bll
{
    public class AdminLogic : IAdminLogic
    {
        public Admin GetAdminByUsername(string username)
        {
            return DaoKeeper.AdminDao.GetAdminByUsername(username);
        }
    }
}
