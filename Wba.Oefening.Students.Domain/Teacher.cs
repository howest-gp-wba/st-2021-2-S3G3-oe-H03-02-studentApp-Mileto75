using System.Collections.Generic;

namespace Wba.Oefening.Students.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}