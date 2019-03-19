using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.lib2
{
    interface IUnitOfWork:IDisposable
    {
        IPatientRepository PatientRepository { get; }
        IStudyRepository StudyRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
        void Commit();
    }
}
