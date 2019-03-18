using System;
using System.Collections.Generic;
using System.Text;

namespace Competition.Repository
{
    public interface IUnitofWork  : IDisposable 
    {
        IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()  where TEntity : class;
        bool Commint();
        void RollBack();
    }
}
