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
            if (db.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {
                bool emailtaken = true;

                return View(emailtaken);
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            if (ModelState.IsValid && db.Users.FirstOrDefault(u => u.Username == user.Username) != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}