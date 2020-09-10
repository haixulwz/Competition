using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockSchoolManagement.Model;
using MockSchoolManagement.Models;

namespace MockSchoolManagement.Controllers
{
    public class HomeController:Microsoft.AspNetCore.Mvc.Controller   
    {
        private IStudentRepository studentRepository;
        public HomeController(IStudentRepository studentRepository) {
            this.studentRepository = studentRepository;
        }
        public ViewResult Index()
        {
            Student student = studentRepository.GetStudent(1);
           
            return View(student);
        }

      
    }
}
