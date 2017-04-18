using KidsAcademy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.EntityModels
{
    public class SubCourseGrade
    {
        public int Id { get; set; }

        public int Student { get; set; }

        public int SubCourse { get; set; }

        public Grade Grade { get; set; }
    }
}
