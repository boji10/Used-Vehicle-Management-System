using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationFinalProjectNiraj2022.Models;

namespace WebApplicationFinalProjectNiraj2022.Controllers
{
    public class vehiclesController : Controller
    {
        private Summer2022Entities1 db = new Summer2022Entities1();

        // GET: vehicles
        public ActionResult Index()
        {
            var vehicles = db.vehicles.Include(v => v.make).Include(v => v.vehicle_model);
            return View(vehicles.ToList());
        }

        // GET: vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: vehicles/Create
        public ActionResult Create()
        {
            ViewBag.make_id = new SelectList(db.makes, "make_id", "name");
            ViewBag.vehicle_model_id = new SelectList(db.vehicle_model, "vehicle_model_id", "colour");
            return View();
        }

        // POST: vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicle_id,make_id,vehicle_model_id,manufature_year,price,cost,sold_date")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.make_id = new SelectList(db.makes, "make_id", "name", vehicle.make_id);
            ViewBag.vehicle_model_id = new SelectList(db.vehicle_model, "vehicle_model_id", "colour", vehicle.vehicle_model_id);
            return View(vehicle);
        }

        // GET: vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.make_id = new SelectList(db.makes, "make_id", "name", vehicle.make_id);
            ViewBag.vehicle_model_id = new SelectList(db.vehicle_model, "vehicle_model_id", "colour", vehicle.vehicle_model_id);
            return View(vehicle);
        }

        // POST: vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicle_id,make_id,vehicle_model_id,manufature_year,price,cost,sold_date")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.make_id = new SelectList(db.makes, "make_id", "name", vehicle.make_id);
            ViewBag.vehicle_model_id = new SelectList(db.vehicle_model, "vehicle_model_id", "colour", vehicle.vehicle_model_id);
            return View(vehicle);
        }

        // GET: vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            db.vehicles.Remove(vehicle);
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
