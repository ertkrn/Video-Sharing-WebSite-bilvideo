using proje1.Common;
using proje1.Core.DataAccess;
using proje1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace proje1.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IDataAccess<T> where T : class
    {
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = context.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);

            //burada urune sessiondan hangi kullanıcının eklediğini insert edecek kod gelecek
            if(obj is Video)
            {
                Video video = obj as Video;

                video.memberId = App.Common.GetCurrentUsernameId();
            }

            return Save();
        }

        public int InsertOther(T obj)
        {
            _objectSet.Add(obj);

            return Save();
        }

        public int Update(T obj)
        {
            if (obj is Video)
            {
                Video video = obj as Video;

                video.memberId = App.Common.GetCurrentUsernameId();
            }
            return Save();
        }

        public int UpdateOther(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
