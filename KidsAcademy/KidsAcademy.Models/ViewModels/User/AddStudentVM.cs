using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.User
{
    public class AddStudentVM
    {
        [Required, MinLength(2)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Рожденна дата")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Адрес на детето")]
        public string Adress { get; set; }

        [Display(Name = "Клас")]
        public Course Course { get; set; }

        //[Display(Name = "Смяна")]
        //public StudentShift StudentShift { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
