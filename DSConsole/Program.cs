using Sample.lib2;
using System;

namespace DSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(new ConnectionFactory()))
            {
                var patient = new Patient { PatientID = 7, PatientDescription = "hello", PatientName = "xdd" };
                var study = new Student { Patient = patient, StudyID = "6", StudyDescription = "ggd" };

                uow.GetRepository<Patient>().Add(patient);
                uow.GetRepository<Student>().Add(study);
                uow.Commit();
            }
           
        }
    }
}
