using System;
using System.Collections.Generic;

namespace Sample.lib2
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
