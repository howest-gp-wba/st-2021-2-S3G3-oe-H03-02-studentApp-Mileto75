using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Web.Models;
using Wba.Oefening.Students.Domain;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository studentRepository;
        private readonly CourseRepository courseRepository;
        private readonly TeacherRepository teacherRepository;

        public HomeController()
        {
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            teacherRepository = new TeacherRepository();
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Student App";
            ViewBag.Message = "Welcome on our Student App";
            return View();
        }

        [Route("Courses")]
        public IActionResult ShowCourses()
        {
            //get the courses
            var courses = courseRepository.Courses;
            //declare view model
            HomeShowCoursesViewModel homeShowCoursesViewModel
                = new HomeShowCoursesViewModel();
            //fill the viewmodel
            homeShowCoursesViewModel.CourseTitles =
                courses.Select(c => c.Name);
            //send to view
            return View(homeShowCoursesViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
