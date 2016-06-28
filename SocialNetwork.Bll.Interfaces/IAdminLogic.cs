using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Bll.Interfaces
{
    public interface IAdminLogic
    {
        Admin GetAdminByUsername(string username);
    }
}
