using System;
using System.Collections.Generic;
 
using System.Text;
 
namespace Sample.lib
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot:class
    {
        public readonly IDbContext dbContext;
        public void Add(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Delete(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
