using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class HomeShowStudentsInCourseViewModel
    {
        public IEnumerable<string> StudentNames
        { get; set; }
        public IEnumerable<string> TeacherNames { get; set; }
        public string CourseTitle { get; set; }
    }
}
