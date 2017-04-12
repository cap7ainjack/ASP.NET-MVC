using System;
using System.Collections.Generic;

namespace KidsAcademy.Models.EntityModels
{
    public class Student
    {
        //public Student()
        //{
        //    this.Courses = new HashSet<Course>();
        //}

        public int Id { get; set; }

        public DateTime Birthdate { get; set; }

        public string Adress { get; set; }

        //public StudentShift StudentShift { get; set; }

        public Parent Parent { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Course Course { get; set; }
    }
}
