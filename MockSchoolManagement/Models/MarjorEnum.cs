using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Models
{
    public enum MarjorEnum
    {
        [Display(Name = "请选择")]
        None,
        [Display(Name = "计算机")]
        FirstGrade,
        [Display(Name = "英语")]
        SecondGrade,
        [Display(Name = "化学")]
        ThirdGrade

    }
}
