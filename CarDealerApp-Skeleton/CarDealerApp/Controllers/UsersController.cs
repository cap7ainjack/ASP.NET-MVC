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

        ////Model state email validation version
        //[HttpPost] 
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Insert a new user into the database
        //        using (UsersContext db = new UsersContext())
        //        {
        //            UserProfile email = db.UserProfiles.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());
        //            try
        //            {
        //                // Check if email already exists
        //                if (email == null)
        //                {
        //                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Email = model.Email });
        //                    WebSecurity.Login(model.UserName, model.Password);
        //                    return RedirectToAction("Index", "Home");
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("Email", "Email address already exists. Please enter a different email address.");
        //                }
        //            }
        //            catch (MembershipCreateUserException e)
        //            {

        //                ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
    }
}