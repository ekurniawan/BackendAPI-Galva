using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        int Insert(T obj);
        int Update(T obj);
        int Delete(T obj);
    }
}
