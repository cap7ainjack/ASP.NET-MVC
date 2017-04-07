using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.Courses
{
   public class DetailsCourseVM
    {
        public string Name { get; set; }

        public ICollection<SubCourseVm> SubCourses { get; set; }
    }
}
