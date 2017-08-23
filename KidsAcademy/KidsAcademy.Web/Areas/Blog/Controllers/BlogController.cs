using KidsAcademy.Models.BindingModels;
using KidsAcademy.Models.ViewModels.Blog;
using KidsAcademy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsAcademy.Web.Areas.Blog.Controllers
{
    public class BlogController : Controller
    {
        private BlogService service;

        public BlogController()
        {
            this.service = new BlogService();
        }

        // GET: Blog/Blog
        [HttpGet]
        public ActionResult Articles()
        {
            IEnumerable<ArticleVM> vms = this.service.GetAllArticles();
            return View(vms);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult Add(AddArticleBM bm)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewArtice(bm, username);
                return RedirectToAction("Articles");
            }

            return this.View();
        }
    }
}