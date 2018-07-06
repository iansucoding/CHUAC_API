using CHUACSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
