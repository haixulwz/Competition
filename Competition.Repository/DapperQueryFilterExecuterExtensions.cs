using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Competition.Repository
{
   public static class DapperQueryFilterExecuterExtensions
    {
        public static IPredicate ExecuteFilter<TEntity, TPrimaryKey>(this Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            IPredicate pg = predicate.ToPredicateGroup<TEntity, TPrimaryKey>();
            return pg;
        }
    }
}
