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
    public class vehicle_typeController : Controller
    {
        private Summer2022Entities1 db = new Summer2022Entities1();

        // GET: vehicle_type
        public ActionResult Index()
        {
            return View(db.vehicle_type.ToList());
        }

        // GET: vehicle_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_type vehicle_type = db.vehicle_type.Find(id);
            if (vehicle_type == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_type);
        }

        // GET: vehicle_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vehicle_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicle_type_id,name")] vehicle_type vehicle_type)
        {
            if (ModelState.IsValid)
            {
                db.vehicle_type.Add(vehicle_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle_type);
        }

        // GET: vehicle_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_type vehicle_type = db.vehicle_type.Find(id);
            if (vehicle_type == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_type);
        }

        // POST: vehicle_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicle_type_id,name")] vehicle_type vehicle_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle_type);
        }

        // GET: vehicle_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_type vehicle_type = db.vehicle_type.Find(id);
            if (vehicle_type == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_type);
        }

        // POST: vehicle_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle_type vehicle_type = db.vehicle_type.Find(id);
            db.vehicle_type.Remove(vehicle_type);
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
