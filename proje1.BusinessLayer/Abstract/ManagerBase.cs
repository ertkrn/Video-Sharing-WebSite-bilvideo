using proje1.Core.DataAccess;
using proje1.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.BusinessLayer.Abstract
{
    public abstract class ManagerBase<T> : IDataAccess<T> where T : class
    {
        private Repository<T> repo = new Repository<T>();

        public int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return repo.Find(where);
        }

        public int Insert(T obj)
        {
            return repo.Insert(obj);
        }
        
        public int InsertOther(T obj)
        {
            return repo.InsertOther(obj);
        }

        public List<T> List()
        {
            return repo.List();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return repo.List(where);
        }

        public IQueryable<T> ListQueryable()
        {
            return repo.ListQueryable();
        }

        public int Save()
        {
            return repo.Save();
        }

        public int Update(T obj)
        {
            return repo.Update(obj);
        }

        public int UpdateOther(T obj)
        {
            return repo.UpdateOther(obj);
        }
    }
}
