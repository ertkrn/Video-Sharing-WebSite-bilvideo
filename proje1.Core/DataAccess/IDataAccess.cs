using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Core.DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> List();

        IQueryable<T> ListQueryable();

        List<T> List(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int InsertOther(T obj);

        int Update(T obj);

        int UpdateOther(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);
    }
}
