using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore
{
    public class DbQueryCommit : IDisposable
    {
        private readonly BloggingContext context;

        public DbQueryCommit(BloggingContext context)
        {
            this.context = context;
        }
        public T Query<T>(params object[] keys) where T : class {
            return this.context.Set<T>().Find(keys);
        }

        public int Commit(Action change) {
            change();
            return context.SaveChanges();
        }
        public DbSet<T> Set<T>() where T : class => context.Set<T>();
        public void Dispose()
        {
            context?.Dispose();
           // throw new NotImplementedException();
        }
    }
}
