using KidsAcademy.Models.ViewModels.Courses;
using KidsAcademy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsAcademy.Web.Controllers
{
    [RoutePrefix("course")]
    public class CourseController : Controller
    {
        private CourseService service;

        public CourseController()
        {
            this.service = new CourseService();
        }

        // GET: Course
        [HttpGet, Route("details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsCourseVM vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return HttpNotFound();
            }

            return this.View(vm);
        }
    }
}