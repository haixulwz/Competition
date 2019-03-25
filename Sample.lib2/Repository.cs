using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DapperExtensions;
namespace Sample.lib2
{
    public class Repository<TEntity> : IEntityRepository<TEntity> where TEntity:class
    {
        protected IDbConnection _connection;
        public Repository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Add(TEntity entity)
        {
            _connection.Get<TEntity>("");
        }
        
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, List<T>> ExecutePageList<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteReaderReturnList<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public T ExecuteReaderReturnT<T>(string sql, object param = null)
        {

            _connection.Query<T>(sql, param);
            throw new NotImplementedException();
        }

        public int ExecuteSqlInt(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
