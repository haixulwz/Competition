using System;
using System.Collections.Generic;
using System.Text;

namespace Competition.Repository
{
    public class UnitofWork : IUnitofWork
    {
        public bool Commint()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
