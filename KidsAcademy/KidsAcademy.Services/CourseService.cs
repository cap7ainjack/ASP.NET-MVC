using AutoMapper;
using KidsAcademy.Models.EntityModels;
using KidsAcademy.Models.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Services
{
   public class CourseService : Service
    {
        public DetailsCourseVM GetDetails(int id)
        {
            Course course = this.Context.Courses.Find(id);
            if (course == null)
            {
                return null;
            }

            DetailsCourseVM vm = Mapper.Map<Course, DetailsCourseVM>(course);
            return vm;
        }
    }
}
