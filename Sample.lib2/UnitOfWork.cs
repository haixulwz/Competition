using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.lib2
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private Dictionary<Type, object> repositories;
        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.GetConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public IPatientRepository PatientRepository => throw new NotImplementedException();

        public IStudyRepository StudyRepository => throw new NotImplementedException();

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }
            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity>(_connection);
            }

            return (IGenericRepository<TEntity>)repositories[type];
        }
    }
}
