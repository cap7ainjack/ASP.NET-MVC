using KidsAcademy.Models.Enums;
using System;
using System.Collections.Generic;

namespace KidsAcademy.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.SubCoursesGrades = new List<SubCourseGrade>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Adress { get; set; }

        //public StudentShift StudentShift { get; set; }

        public Parent Parent { get; set; }

        public int Course { get; set; }

        public virtual IEnumerable<SubCourseGrade> SubCoursesGrades { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
