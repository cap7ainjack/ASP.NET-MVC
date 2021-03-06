﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.EntityModels
{
   public class Teacher 
    {
       public Teacher()
       {
           this.Students = new HashSet<Student>();
           this.Courses = new HashSet<Course>();
       }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
