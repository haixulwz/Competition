using System;

namespace Sample.lib
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot:class
    {
        void Add(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        void Delete(TAggregateRoot aggregateRoot);

        TAggregateRoot Get(int id);
    }
}
