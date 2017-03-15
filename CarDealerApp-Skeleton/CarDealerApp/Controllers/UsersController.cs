using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    public class UsersController : Controller
    {
        private CarDealerContext db = new CarDealerContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Email,Password")] User user)
        {
            if (ModelState.IsValid && db.Users.FirstOrDefault(u => u.Email == user.Email) == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Redirect("users/login");
            }

            return View("<h2> user with that e-mail already exist <h2>");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            if (ModelState.IsValid && db.Users.FirstOrDefault(u => u.Username == user.Username) != null)
            {
                  
            }

            return View("Login unsuccessful");
        }
    }
}