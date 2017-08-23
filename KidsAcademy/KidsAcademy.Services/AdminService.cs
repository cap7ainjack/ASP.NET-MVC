using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsAcademy.Models.ViewModels.Admin;
using KidsAcademy.Models.EntityModels;
using KidsAcademy.Models.ViewModels.Courses;
using AutoMapper;

namespace KidsAcademy.Services
{
    public class AdminService : Service
    {
        public AdminPageVM GetAdminPage()
        {
            AdminPageVM page = new AdminPageVM();
            IEnumerable<Course> courses = this.Context.Courses;
            IEnumerable<ApplicationUser> users = this.Context.Users;

            IEnumerable<CourseVM> coursesVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVM>>(courses);
            IEnumerable<AdminPageUserVM> usersVms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AdminPageUserVM>>(users);

            page.Users = usersVms;
            page.Courses = coursesVms;

            return page;
        }

        public DetailsCourseVM GetCourseForEdit(int id)
        {
            Course course = Context.Courses.FirstOrDefault(c => c.Id == id);
            DetailsCourseVM vm = Mapper.Map<Course, DetailsCourseVM>(course);

            return vm;
        }

        public IEnumerable<CourseVM> GetAllCourses()
        {
            var courses = this.Context.Courses;
            IEnumerable<CourseVM> courseVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVM>>(courses);

            return courseVms;
        }
    }
}
