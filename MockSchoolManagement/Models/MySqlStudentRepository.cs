using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MockSchoolManagement.Ef;
using MockSchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Models
{
    public class MySqlStudentRepository : IStudentRepository
    {
        private AppDbContext context;
        public MySqlStudentRepository(AppDbContext c) {
            context = c;
        }
        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
            //throw new NotImplementedException();
        }

        public Student Delete(int id)
        {
            var student = context.Students.Find(id);
            if (student!=null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
           // throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
            //throw new NotImplementedException();
        }

        public Student GetStudent(int id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public void Save(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public Student Update(Student student)
        {
            var s = context.Students.Attach(student);
            s.State = EntityState.Modified;
            context.SaveChanges();
            return student;
           // throw new NotImplementedException();
        }
    }
}
