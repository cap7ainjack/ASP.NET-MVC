using AutoMapper;
using KidsAcademy.Models.EntityModels;
using KidsAcademy.Models.ViewModels.Courses;
using System.Collections.Generic;

namespace KidsAcademy.Services
{
    public class HomeService :Service
    {

        public IEnumerable<CourseVM> GetAllCourses()
        {
            IEnumerable<Course> coursees = this.Context.Courses;
            IEnumerable<CourseVM> vms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVM>> (coursees);
            return vms;
        }
    }
}
