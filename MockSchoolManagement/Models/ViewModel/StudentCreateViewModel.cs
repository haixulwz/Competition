using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Models.ViewModel
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage ="姓名必填"),MaxLength(20,ErrorMessage ="最大只能50")]
        public string Name { get; set; }

        public MarjorEnum? Major { get; set; }
    
        public string Email { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
