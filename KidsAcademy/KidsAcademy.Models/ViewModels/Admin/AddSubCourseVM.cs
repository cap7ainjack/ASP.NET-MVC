using KidsAcademy.Models.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.Admin
{
   public class AddSubCourseVM
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int HoursPerWeek { get; set; }

        public IEnumerable<CourseVM> Courses { get; set; }
    }
}
