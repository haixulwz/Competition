﻿using Competition.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;
using System.Linq;

namespace Competition.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        private readonly IDbConnection _connection;//= DbConnectionHelper.GetConnection();
        public Repository(IDbConnection connection=null)
        {
            _connection = connection;
            if (_connection == null  )
            {
                _connection = DbConnectionHelper.GetConnection();
            }
        }
        public int Count()
        {

            return Count(null);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate!=null)
            {
                var filteredPredicate = predicate.ExecuteFilter<TEntity, TPrimaryKey>();

            }
            return _connection.Count<TEntity>(predicate);
           // throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult<int>(Count());
        }

        public   Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return   Task.FromResult(Count(predicate)) ;
        }

        public void Delete(TEntity entity)
        {
            _connection.Delete(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _connection.Delete(predicate);
        }

        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult (0);
           //  throw new Exception("");
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
          //  throw new NotImplementedException();
        }

        public int Execute(string query, object parameters = null)
        {
            return _connection.Execute(query, parameters);
        }

        public Task<int> ExecuteAsync(string query, object parameters = null)
        {
            return Task.FromResult(Execute(query,parameters));
            //throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            IPredicate pg = predicate.ExecuteFilter<TEntity, TPrimaryKey>();
           return   _connection.GetList<TEntity>(pg).FirstOrDefault();
            //return _connection.Query<TEntity>()
          // throw new NotImplementedException();
        }
 

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return _connection.Get<TEntity>(id);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

      

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

      

        public TEntity Get(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            throw new NotImplementedException();
        }

        
        public Task<TEntity> GetAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Query(string query, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TPrimaryKey IRepository<TEntity, TPrimaryKey>.InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TPrimaryKey> IRepository<TEntity, TPrimaryKey>.InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TPrimaryKey IRepository<TEntity, TPrimaryKey>.InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TPrimaryKey> IRepository<TEntity, TPrimaryKey>.InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
