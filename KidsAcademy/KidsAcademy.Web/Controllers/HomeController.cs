using KidsAcademy.Models.ViewModels.Courses;
using KidsAcademy.Services;
using KidsAcademy.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsAcademy.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        public ActionResult Index()
        {
            IEnumerable<CourseVM> vms = service.GetAllCourses();
            return View(vms);
        }

    }
}