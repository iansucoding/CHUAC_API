using CHUACSystem.Data;
using CHUACSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ACSystemDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(ACSystemDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        protected void Save() => _context.SaveChanges();

        public IQueryable<T> GetQueryable()
        {
            return _entities.AsQueryable();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
