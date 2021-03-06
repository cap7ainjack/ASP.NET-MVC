﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;
using CarDealerApp.Services;
using CarDealer.Models.BindingModels;
using CarDealerApp.Security;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("Cars")]
    public class CarsController : Controller
    {
        private CarDealerContext db = new CarDealerContext();
        private CarsService service = new CarsService();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        [Route("{id}/parts")]
        public ActionResult Parts(int id)
        {
            Car car = db.Cars.FirstOrDefault(c => c.Id == id);
            IEnumerable<Part> parts;
            if (car != null)
            {
                parts = car.Parts.ToArray();
                return View(parts);
            }

            return View();
        }

        [Route("{id}")]
        public ActionResult Make(string id)
        {
            IEnumerable<Car> cars = db.Cars.Where(car => car.Make == id).ToArray();

            return View(cars);
        }

        // GET: Cars/Details/5

        [HttpGet]
        [Route("details/{id}")]
        [HandleError(View = "CarDetailsError", ExceptionType = typeof(ArgumentOutOfRangeException))]
       // [Log]
        public ActionResult Details(int id)
        {
            var context = new CarDealerContext();
            var car = context.Cars.Find(id);
            if (car == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id), id, $"There is no such element with provided ID.");
            }
            else if (car.TravelledDistance > 1000000)
            {
                throw new InvalidOperationException("The car is too old to be displayed");
            }
            ViewData["car"] = car;

            return this.View();
        }

        // GET: Cars/Create
        //[Authorize]
        [Route("Add")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !Security.AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            var partsForVM = service.GetPartsForDropdown();
            return View(partsForVM);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Make, Model, TravelledDistance, Part1, Part2, Part3")] NewCarBindingModel car)
        {
            Car newCar = service.AddNewCar(car, db);

            if (ModelState.IsValid)
            {
                db.Cars.Add(newCar);
                db.SaveChanges();
                return Redirect("/Cars");
            }

            return View(car);
        }

        //GET


        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,TravelledDistance")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
