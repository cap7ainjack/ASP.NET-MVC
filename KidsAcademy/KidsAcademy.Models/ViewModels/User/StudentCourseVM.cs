using KidsAcademy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.User
{
   public class StudentCourseVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public int Course { get; set; }

        public IEnumerable<ProfileSubCourseVM> SubCoursesGrades { get; set; }
    }
}
