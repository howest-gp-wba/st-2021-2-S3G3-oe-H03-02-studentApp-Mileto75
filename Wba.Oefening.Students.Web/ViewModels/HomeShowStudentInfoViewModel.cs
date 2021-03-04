using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class HomeShowStudentInfoViewModel
    {
        public string StudentName { get; set; }
        public IEnumerable<string> StudentCourses { get; set; }
    }
}
