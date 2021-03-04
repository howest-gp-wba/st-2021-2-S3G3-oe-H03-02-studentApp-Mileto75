using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wba.Oefening.Students.Domain
{
    public class StudentRepository
    {
        public IEnumerable<Student> Students { get; set; }
        public CourseRepository CourseRepository { get; set; }

        public StudentRepository()
        {
            CourseRepository = new CourseRepository();
            Students = new List<Student>
            {
                new Student{
                    Id = 1,
                    FirstName ="Dirk",
                    LastName ="Diggler",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 2),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6),
                    }
                },
                new Student{
                    Id = 2,
                    FirstName ="Mike",
                    LastName ="Tyson",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6),
                    }
                },
                new Student{
                    Id = 3,
                    FirstName ="Bill",
                    LastName ="Wyman",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 2),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                    }
                },
                new Student{
                    Id = 4,
                    FirstName ="Jimi",
                    LastName ="Hendrix",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 3),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6),
                    }
                },
                new Student{
                    Id = 5,
                    FirstName ="Marylin",
                    LastName ="Monroe",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 4),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6),
                    }
                },
                new Student{
                    Id = 6,
                    FirstName ="Billy",
                    LastName ="Idol",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 3),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 2),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 4),
                    }
                },
                new Student{
                    Id = 7,
                    FirstName ="Janis",
                    LastName ="Joplin",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 1),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 2),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 6),
                    }
                },
                new Student{
                    Id = 8,
                    FirstName ="Willie",
                    LastName ="Nelson",
                    Courses = new List<Course>
                    {
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 3),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 4),
                        CourseRepository.Courses.FirstOrDefault(c => c.Id == 5),
                    }
                },
            };
        }

        //gets the student by id
        public Student GetStudentById(long studentId)
        {
            return Students.FirstOrDefault(s => s.Id == studentId);
        }

        //gets the students by CourseId
        public IEnumerable<Student> GetStudentsInCourseId(long courseId)
        {
            //Any retourneert een boolean op basis van de conditie
            return Students.Where(s => s.Courses.Any(c => c.Id == courseId));
        }

        //get a student courses
        public IEnumerable<Course> GetCoursesForStudentById(long studentId)
        {
            return Students.FirstOrDefault(s => s.Id == studentId).Courses;
        }
    }
}
