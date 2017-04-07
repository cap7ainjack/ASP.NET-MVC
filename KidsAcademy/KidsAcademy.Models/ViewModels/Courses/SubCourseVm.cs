using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.Courses
{
    public class SubCourseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Часове на седмица")]
        public int HoursPerWeek { get; set; }
    }
}
