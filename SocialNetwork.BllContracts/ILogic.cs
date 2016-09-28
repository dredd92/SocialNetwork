using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BllContracts
{
    public interface ILogic<T>
    {
        T Get(int id);

        bool Remove(int id);

        bool Update(int id, T newValue);

        bool Add(T value);
    }
}
