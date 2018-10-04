using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Get();
        T Get(int id);
        T Update(T value);
        T Insert(T value);
        int Delete(T value);
    }
}