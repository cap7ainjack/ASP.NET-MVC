using KidsAcademy.Models.ViewModels.Admin;
using KidsAcademy.Models.ViewModels.Courses;
using KidsAcademy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsAcademy.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageVM vm = this.service.GetAdminPage();
            return View(vm);
        }

        [HttpGet]
        [Route("course/add")]
        public ActionResult AddCourse()
        {
            return this.View();
        }

        [HttpGet]
        [Route("course/{id}/edit")]
        public ActionResult EditCourse(int id)
        {
            DetailsCourseVM vm = this.service.GetCourseForEdit(id);
            return this.View(vm);
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            var model = new AddSubCourseVM
            {
                Courses = this.service.GetAllCourses()
            };

            return this.View(model);
        }

        [HttpGet]

        public ActionResult AddSubCourse()
        {

            return this.View();
        }
    }
}