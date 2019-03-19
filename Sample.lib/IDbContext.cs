using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.lib
{
  public  interface IDbContext
    {
        //DbSet<TEntity> Set<TEntity>()
        //where TEntity : class;

        //DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        //    where TEntity : class;

        int SaveChanges();
    }
}
