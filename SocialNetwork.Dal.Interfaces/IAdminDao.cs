using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Dal.Interfaces
{
    public interface IAdminDao
    {
        Admin GetAdminByUsername(string username);
    }
}
