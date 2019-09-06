using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;

namespace TestProject.WebApp.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly TestProjectContext _context;
        public BaseRepository()
        {
            _context = new TestProjectContext();
            _dbSet = _context.Set<TEntity>();

        }
        public TEntity GetItem(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            SaveChanges();
        }

        public void Edit(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var item = GetItem(id);
            _dbSet.Remove(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}