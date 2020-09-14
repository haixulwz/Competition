using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MockSchoolManagement.Model;
using MockSchoolManagement.Models;
using MockSchoolManagement.Models.ViewModel;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IStudentRepository studentRepository;
        private IWebHostEnvironment webHostEnvironment;
        public HomeController(IStudentRepository studentRepository,IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
        public ViewResult Details(int id = 1)
        {
            StudentDetailViewModel vm = new StudentDetailViewModel()
            {

                Student = studentRepository.GetStudent(id),
                PageTitle = "学生详情"
            };
            return View(vm);

        }
        [HttpGet]
        [Route("Home/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqu = null;
                if (model.Photo!=null) {
                    string uploadPathFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqu = Guid.NewGuid() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadPathFolder,uniqu);
                    model.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }

                Student s = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Major = model.Major,
                    PhotoPath = uniqu 
                }; 
                    studentRepository.Add(s);
                return RedirectToAction("Details", new { id = s.Id });
            }
            return View();
        }
    }
}
