﻿using AutoMapper;
using KidsAcademy.Models.BindingModels;
using KidsAcademy.Models.EntityModels;
using KidsAcademy.Models.ViewModels.Admin;
using KidsAcademy.Models.ViewModels.Blog;
using KidsAcademy.Models.ViewModels.Courses;
using KidsAcademy.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KidsAcademy.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Course, CourseVM>();
                expression.CreateMap<Course, DetailsCourseVM>();
                expression.CreateMap<SubCourse, SubCourseVm>();

                //    expression.CreateMap<AddStudentBM, Student>()
                //        .ForMember(c => c.Course,
                //            opt => opt.MapFrom(o =>
                //               new Data.KidsAcademyContext().Courses.Find(o.Course)
                //                              )
                //            );

                expression.CreateMap<AddStudentBM, Student>();
                expression.CreateMap<ApplicationUser, ParentProfileVM>();

                expression.CreateMap<Student, StudentCourseVM>()
                    .ForMember(vm => vm.SubCoursesGrades,
                        stu => stu.MapFrom(s => s.SubCoursesGrades));

                expression.CreateMap<SubCourseGrade, ProfileSubCourseVM>()
                     .ForMember(vm => vm.Name,
                        ent => ent.MapFrom(e => new Data.KidsAcademyContext().SubCourses.Find(e.Id).Name));

                expression.CreateMap<ApplicationUser, EditUserVM>();
                expression.CreateMap<Article, ArticleVM>();
                expression.CreateMap<ApplicationUser, ArticleAuthorVM>();
                expression.CreateMap<AddArticleBM, Article>();
                expression.CreateMap<ApplicationUser, AdminPageUserVM>();
            });
        }
    }
}
