using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T t);
        void Tupdate(T t);
        void Tdelete(T t);
        List<T> TGetList();
        T GetById(int id);
    }
}
