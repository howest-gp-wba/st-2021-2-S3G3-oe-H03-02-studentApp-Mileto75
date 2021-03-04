using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class HomeShowCoursesViewModel
    {
        //public IEnumerable<string> 
        //    CourseTitles { get; set; }
        //List<string> CourseTitles;
        public List<HomeCoursesViewModel> Courses { get; set; }
        = new List<HomeCoursesViewModel>();
    }
}
