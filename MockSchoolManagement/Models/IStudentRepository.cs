using MockSchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MockSchoolManagement.Model
{
    public   interface IStudentRepository
    {
        Student GetStudent(int id);
        void Save(Student student);
        IEnumerable<Student> GetAll();
        Student Add(Student student);

        Student Delete(int id);
        Student Update(Student student);
    }

    public class StudentRepository : IStudentRepository
    {
        private IList<Student> students;
        public StudentRepository() {
            students = new List<Student>() { 
                //new Student(){ Id=1,Name="张珊",Major="English"},
                //new Student(){ Id=2,Name="李四",Major="Chemistery"},
                //new Student(){ Id=3,Name="wangwu",Major="History"}
            
            };
        }

        public Student Add(Student student)
        {
            var id = students.Max(x => x.Id) + 1;
            student.Id = id;
            students.Add(student);
            return student;

        }

        public Student Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(x=>x.Id==id);
            //throw new NotImplementedException();
        }

        public void Save(Student student)
        {
            students.Add(student);
            //throw new NotImplementedException();
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
