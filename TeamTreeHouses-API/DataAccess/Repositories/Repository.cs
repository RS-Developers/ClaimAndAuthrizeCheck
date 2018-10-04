using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private StatesDbContext _lContext = null;

        public virtual List<T> Get()
        {
            return _lContext.Set<T>().ToList();
        }

        public virtual T Get(int id)
        {
            return _lContext.Set<T>().Find(id);
        }

        public virtual T Insert(T value)
        {
            _lContext.Set<T>().Add(value);
            _lContext.SaveChanges();
            return value;
        }

        public virtual T Update(T value)
        {
            _lContext.Entry(value).State = System.Data.Entity.EntityState.Modified;
            _lContext.SaveChanges();
            //
            //var lUpdateEntity = _lContext.Set<T>().Attach(value);
            return value;
        }

        public virtual int Delete(T value)
        {
            _lContext.Set<T>().Remove(value);
            return _lContext.SaveChanges();
        }

        public Repository(StatesDbContext context)
        {
            _lContext = context;
        }
    }
}