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

        public string Description { get; set; }

        [Display(Name = "Hours per day")]
        public int Duration { get; set; }
    }
}
