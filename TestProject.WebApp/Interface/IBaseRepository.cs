using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.WebApp.Interface
{
   public interface  IBaseRepository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetItem(int id);

        void AddOrUpdate(TEntity item);

        void Edit(TEntity item);

        void Delete(int id);

    }
}