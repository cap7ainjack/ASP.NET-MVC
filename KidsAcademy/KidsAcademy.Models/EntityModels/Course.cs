using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.EntityModels
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.SubCourses = new HashSet<SubCourse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<SubCourse> SubCourses { get; set; }
    }
}
