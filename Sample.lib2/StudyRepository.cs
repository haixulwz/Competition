using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.lib2
{
   public class StudyRepository: GenericRepository<Student>, IStudyRepository
    {
        public StudyRepository(IDbConnection connection) : base(connection)
        {

        }
        public void Add(Student entity)
        {
            _connection.Execute(
                "insert into Study(StudyID,StudyDescription,PatientID) values(@StudyID,@StudyDescription,@PatientID)",
                new
                {
                 
                });
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Student Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
 
    }
}
