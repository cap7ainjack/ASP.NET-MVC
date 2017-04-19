using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.ViewModels.User
{
   public class ParentProfileVM
    {
        public string FirstName { get; set; }

        public string Email { get; set; }

        public IEnumerable<StudentCourseVM> Kids { get;set;}
    }
}
