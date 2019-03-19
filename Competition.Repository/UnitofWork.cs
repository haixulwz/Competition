using Competition.DbHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Competition.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DbConnection _connection = new MySqlConnection("");
        
        public bool Commint()
        {
            IDbTransaction transaction=_connection.BeginTransaction();
           // _connection = transaction.Connection;
            transaction.Commit();
           // _connection.BeginTransaction();
          //  _connection.CreateCommand 
             throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>() where TEntity : class
        {
            
            return new Repository<TEntity, TPrimaryKey>(_connection);
           // throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
