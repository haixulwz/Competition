using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Models.ViewModel
{
    public class StudentEditViewModel:StudentCreateViewModel
    {
        public int Id { get; set; }

        public string ExistPhotoPath { get; set; }
    }
}
