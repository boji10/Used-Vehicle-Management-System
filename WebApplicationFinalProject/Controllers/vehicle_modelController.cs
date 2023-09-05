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
    public class vehicle_modelController : Controller
    {
        private Summer2022Entities1 db = new Summer2022Entities1();

        // GET: vehicle_model
        public ActionResult Index()
        {
            var vehicle_model = db.vehicle_model.Include(v => v.vehicle_type);
            return View(vehicle_model.ToList());
        }

        // GET: vehicle_model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_model vehicle_model = db.vehicle_model.Find(id);
            if (vehicle_model == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_model);
        }

        // GET: vehicle_model/Create
        public ActionResult Create()
        {
            ViewBag.vehicle_type_id = new SelectList(db.vehicle_type, "vehicle_type_id", "name");
            return View();
        }

        // POST: vehicle_model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicle_model_id,engine_size,number_of_doors,colour,vehicle_type_id")] vehicle_model vehicle_model)
        {
            if (ModelState.IsValid)
            {
                db.vehicle_model.Add(vehicle_model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vehicle_type_id = new SelectList(db.vehicle_type, "vehicle_type_id", "name", vehicle_model.vehicle_type_id);
            return View(vehicle_model);
        }

        // GET: vehicle_model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_model vehicle_model = db.vehicle_model.Find(id);
            if (vehicle_model == null)
            {
                return HttpNotFound();
            }
            ViewBag.vehicle_type_id = new SelectList(db.vehicle_type, "vehicle_type_id", "name", vehicle_model.vehicle_type_id);
            return View(vehicle_model);
        }

        // POST: vehicle_model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicle_model_id,engine_size,number_of_doors,colour,vehicle_type_id")] vehicle_model vehicle_model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle_model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vehicle_type_id = new SelectList(db.vehicle_type, "vehicle_type_id", "name", vehicle_model.vehicle_type_id);
            return View(vehicle_model);
        }

        // GET: vehicle_model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_model vehicle_model = db.vehicle_model.Find(id);
            if (vehicle_model == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_model);
        }

        // POST: vehicle_model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle_model vehicle_model = db.vehicle_model.Find(id);
            db.vehicle_model.Remove(vehicle_model);
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
