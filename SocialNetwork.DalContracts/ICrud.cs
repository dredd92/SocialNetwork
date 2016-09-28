using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DalContracts
{
    public interface ICrud<T>
    {
        T Get(int id);

        bool Remove(int id);

        bool Add(T value);

        bool Update(int id, T newValue);
    }
}
