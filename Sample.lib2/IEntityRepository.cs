using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.lib2
{
   public interface IEntityRepository<TEntity>:INoEntityRepository
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
