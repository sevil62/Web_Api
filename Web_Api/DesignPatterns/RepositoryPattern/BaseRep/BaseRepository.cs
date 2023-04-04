using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Web_Api.DesignPatterns.SingletonPattern;
using Web_Api.Models.Context;
using Web_Api.Models.Entities;

namespace Web_Api.DesignPatterns.RepositoryPattern.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MyContext _db;
        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = Models.Enums.DataStatus.Deleted;
            Save();

        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != Models.Enums.DataStatus.Deleted);
        }

        public virtual List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == Models.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == Models.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            T toBeUpdated = Find(item.ID);
            item.Status = Models.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
}