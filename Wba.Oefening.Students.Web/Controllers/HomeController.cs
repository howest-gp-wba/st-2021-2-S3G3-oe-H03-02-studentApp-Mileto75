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

        [Route("Students")]
        public IActionResult ShowStudents()
        {
            //get the students
            var students = studentRepository.Students;
            //viewModel
            HomeShowStudentsViewModel homeShowStudentsViewModel
                = new HomeShowStudentsViewModel();
            homeShowStudentsViewModel.StudentNames
                = students
                .Select(s => $"{s.FirstName} " +
                $"{s.LastName}")
                .ToList();
            return View(homeShowStudentsViewModel);
        }

        
        [Route("Courses/{courseId:long}/students")]
        public IActionResult ShowStudentsInCourse(long courseId)
        {
            //reuse view model and view
            ////get the students in courseId
            //var students = studentRepository
            //    .GetStudentsInCourseId(courseId);
            ////declare model
            //HomeShowStudentsViewModel
            //    homeShowStudentsInCourseViewModel
            //    = new HomeShowStudentsViewModel();
            //homeShowStudentsInCourseViewModel
            //    .StudentNames
            //    = students.Select(s => $"{s.FirstName} {s.LastName}")
            //    .ToList();
            ////pass to the view
            //return View("ShowStudents", homeShowStudentsInCourseViewModel);

            //with own view model and view
            //get the students in courseId
            var students = studentRepository
                .GetStudentsInCourseId(courseId);
            //get the teachers from courseId
            var teachers = teacherRepository
                .GetTeachersByCourseId(courseId);
            //get the course title
            var courseTitle = courseRepository
                .GetCourseById(courseId)
                .Name;
            //declare model
            HomeShowStudentsInCourseViewModel
                homeShowStudentsInCourseViewModel
                = new HomeShowStudentsInCourseViewModel();
            homeShowStudentsInCourseViewModel
                .StudentNames
                = students.Select(s => $"{s.FirstName} {s.LastName}");
            homeShowStudentsInCourseViewModel.TeacherNames =
                teachers.Select(t => $"{t.FirstName} {t.LastName}");
            homeShowStudentsInCourseViewModel.CourseTitle = courseTitle;
            //pass to the view
            return View(homeShowStudentsInCourseViewModel);
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Student App";
            ViewBag.Message = "Welcome on our Student App";
            return View();
        }

        
        [Route("students/{studentId:long}")]
        public IActionResult ShowStudentInfo(long studentId)
        {
            //get the data
            var student = studentRepository.GetStudentById(studentId);

            var studentCourses = studentRepository.GetCoursesForStudentById(studentId);
            //use course collection from student class
            /*var studentCourses = student.Courses;*/
            //viewmodel
            HomeShowStudentInfoViewModel homeShowStudentInfoViewModel
                = new HomeShowStudentInfoViewModel();
            //fill the model
            homeShowStudentInfoViewModel.StudentName
                = $"{student.FirstName} {student.LastName}";
            homeShowStudentInfoViewModel.StudentCourses = studentCourses.Select(c => c.Name);
            //pass to view
            return View(homeShowStudentInfoViewModel);
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
            //loop through courses
            foreach(var course in courses)
            {
                homeShowCoursesViewModel.Courses.Add(
                    new HomeCoursesViewModel
                    {
                        Id = course?.Id,
                        CourseTitle = course?.Name
                    }
                    );
            }
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
