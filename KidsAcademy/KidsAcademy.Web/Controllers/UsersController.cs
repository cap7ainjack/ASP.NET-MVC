using KidsAcademy.Models.BindingModels;
using KidsAcademy.Models.EntityModels;
using KidsAcademy.Models.ViewModels.User;
using KidsAcademy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsAcademy.Web.Controllers
{
    [Authorize(Roles = "Parent")]
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        [Route("enroll")]
        public ActionResult Enroll()
        {
            var model = new AddStudentVM
            {
                Courses = this.service.GetAllCourses()
            };

            string userName = this.User.Identity.Name;
            return this.View(model);
        }

        [HttpPost]
        [Route("enroll")]
        public ActionResult Enroll([Bind(Include = "FirstName, LastName,Birthdate, Adress, Course")] AddStudentBM student)
        {
            string userName = this.User.Identity.Name;

            if (ModelState.IsValid)
            {
                this.service.AddStudent(student, userName);
                return RedirectToAction("Profile");
            }

            return View("Error");
        }
        public ActionResult Profile()
        {
            string userName = this.User.Identity.Name;
            ParentProfileVM vm = this.service.GetProfileVM(userName);

            return this.View();
        }
    }
}