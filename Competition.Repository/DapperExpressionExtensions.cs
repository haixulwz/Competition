using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Competition.Repository
{
    public static class DapperExpressionExtensions
    {
        public static IPredicate ToPredicateGroup<TEntity, TPrimaryKey>(this Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            var dev = new DapperExpressionVisitor<TEntity, TPrimaryKey>();
            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}
