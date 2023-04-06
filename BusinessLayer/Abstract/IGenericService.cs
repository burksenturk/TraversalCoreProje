using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    { // concrete tarafında yapacagım business metotlarının imzalarını burada tutmak istiyorum

        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);
       // List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
