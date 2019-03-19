using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sample.lib2
{
  public  class PatientRepository: GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(IDbConnection connection):base(connection)
        {

        }
        public void Add(Patient entity)
        {
            _connection.Execute(
                "insert into Patient(PatientID,PatientName, PatientDescription) values(@PatientID, @PatientName,@PatientDescription)",
                entity);
        }

        public void Delete(Patient entity)
        {
            throw new System.NotImplementedException();
        }

        public Patient Get(int Id)
        {
            return _connection.Query<Patient>("select * from Patient where PatientID=@id", new { id = Id }).SingleOrDefault();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new System.NotImplementedException();
        }
 
    }
}
