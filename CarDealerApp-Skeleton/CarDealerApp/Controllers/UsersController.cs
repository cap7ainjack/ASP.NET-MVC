using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using CarDealerApp.Security;
using CarDealerApp.Services;
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
        private UserService service = new UserService();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies["sessionId"];
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Email,Password")] RegisterUserBm userBM)
        {
            var httpCookie = this.Request.Cookies["sessionId"];
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Index", "Home");
            }

            if (db.Users.FirstOrDefault(u => u.Email == userBM.Email) != null)
            {
                bool emailtaken = true;

                return View(emailtaken);
            }

            if (ModelState.IsValid )
            {
                this.service.RegisterUser(userBM);
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies["sessionId"];
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] LoginUserBM userBM)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == userBM.Username && u.Password == userBM.Password);
            var httpCookie = this.Request.Cookies["sessionId"];

            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && user != null)
            {
                service.LoginUser(userBM, Session.SessionID);
                this.Response.SetCookie(new HttpCookie("sessionId", Session.SessionID));
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("users/logout")]
        public ActionResult Logout()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login");
            }

            AuthenticationManager.Logout(Request.Cookies.Get("sessionId").Value);
            return this.RedirectToAction("All", "Cars");
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