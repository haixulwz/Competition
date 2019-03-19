using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.lib
{
    public interface IStudentRepository:IRepository<Student>
    {
        Student GetByName(string name);
    }
}
