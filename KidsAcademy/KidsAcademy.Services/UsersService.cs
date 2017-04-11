using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Services
{
   public class UsersService : Service
    {

        public void EnrollStudentInCourse(int courseId, Student student)
        {
            Course wantedCourse = this.Context.Courses.Find(courseId);
            student.Course = wantedCourse;
            this.Context.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = this.Context.Courses.ToArray();
            return courses;
        }
    }
}
