using System.Collections.Generic;
using System.Linq;

namespace Wba.Oefening.Students.Domain
{
    public class CourseRepository
    {
        public IEnumerable<Course> Courses { get; set; }
        public StudentRepository Students { get; set; }
        public TeacherRepository TeacherRepository { get; set; }

        public CourseRepository()
        {
            Courses = new List<Course>
            {
                new Course{Id=1, Name = "Web Backend" },
                new Course{Id=2, Name = "Programming Basics" },
                new Course{Id=3, Name = "Programmng Expert" },
                new Course{Id=4, Name = "Databases" },
                new Course{Id=5, Name = "CI Basics" },
                new Course{Id=6, Name = "CI Advanced" },
            };
        }


        //gets a course by id
        public Course GetCourseById(long courseId)
        {
            return Courses.FirstOrDefault(s => s.Id == courseId);
        }
    }
}