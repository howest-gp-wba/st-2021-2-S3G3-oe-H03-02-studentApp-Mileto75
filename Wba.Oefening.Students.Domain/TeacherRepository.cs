using System.Collections.Generic;
using System.Linq;

namespace Wba.Oefening.Students.Domain
{
    public class TeacherRepository
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public CourseRepository CourseRepository { get; set; }
        public TeacherRepository()
        {
            CourseRepository = new CourseRepository();
            Teachers = new
            List<Teacher>
            {
                new Teacher{
                    Id = 1,
                    FirstName = "Mark",
                    LastName = "Knopfler",
                    Courses= new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 2),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 3),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 4)
                    }
                },
                new Teacher{
                    Id = 2,
                    FirstName = "Stevie",
                    LastName = "Nicks",
                    Courses= new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 4),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6)
                    }
                },
            };
        }


        //gets the teacher by id
        public Teacher GetTeacherById(long teacherId)
        {
            return Teachers.FirstOrDefault(t => t.Id == teacherId);
        }

        //gets all teachers teaching a course id
        public IEnumerable<Teacher> GetTeachersByCourseId(long courseId)
        {
            return Teachers.Where(e => e.Courses.Any(c => c.Id == courseId));
        }

    }
}