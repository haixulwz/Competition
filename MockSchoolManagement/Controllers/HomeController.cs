using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MockSchoolManagement.Model;
using MockSchoolManagement.Models;
using MockSchoolManagement.Models.ViewModel;

namespace MockSchoolManagement.Controllers
{
    public class HomeController:Microsoft.AspNetCore.Mvc.Controller   
    {
        private IStudentRepository studentRepository;
        public HomeController(IStudentRepository studentRepository) {
            this.studentRepository = studentRepository;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var students = studentRepository.GetAll();
           
            return View(students);
        }
        [Route("Home/Details/{id?}")]
        public ViewResult Details(int id=1) {
            StudentDetailViewModel vm = new StudentDetailViewModel()
            {
                
                Student = studentRepository.GetStudent(id),
                PageTitle = "学生详情"
            };
            return View(vm);
            
        }
    }
}
