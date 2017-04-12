using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsAcademy.Models.ViewModels.User;
using AutoMapper;
using KidsAcademy.Models.BindingModels;

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

        public void AddStudent(AddStudentBM student, string userName)
        {
            Student studentToAdd = Mapper.Map<AddStudentBM, Student>(student);
            studentToAdd.Parent = this.Context.Parents.FirstOrDefault(parent => parent.User.UserName == userName);

            this.Context.Students.Add(studentToAdd);
            this.Context.SaveChanges();
        }
    }
}
