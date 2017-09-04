using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgramPlanner.Models;

namespace ProgramPlanner.Controllers
{
    public class OptionalDirectedsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: OptionalDirecteds
        public ActionResult Index()
        {
            var directeds = db.Directeds.Include(o => o.Course).Include(o => o.DirectedSlot);
            return View(directeds.ToList());
        }

        // GET: OptionalDirecteds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalDirected optionalDirected = db.Directeds.Find(id);
            if (optionalDirected == null)
            {
                return HttpNotFound();
            }
            return View(optionalDirected);
        }

        // GET: OptionalDirecteds/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.DirectedSlotID = new SelectList(db.DirectedSlots, "DirectedSlotID", "rule");
            return View();
        }

        // POST: OptionalDirecteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OptionalDirectedID,CourseID,DirectedSlotID")] OptionalDirected optionalDirected)
        {
            if (ModelState.IsValid)
            {
                db.Directeds.Add(optionalDirected);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", optionalDirected.CourseID);
            ViewBag.DirectedSlotID = new SelectList(db.DirectedSlots, "DirectedSlotID", "rule", optionalDirected.DirectedSlotID);
            return View(optionalDirected);
        }

        // GET: OptionalDirecteds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalDirected optionalDirected = db.Directeds.Find(id);
            if (optionalDirected == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", optionalDirected.CourseID);
            ViewBag.DirectedSlotID = new SelectList(db.DirectedSlots, "DirectedSlotID", "rule", optionalDirected.DirectedSlotID);
            return View(optionalDirected);
        }

        // POST: OptionalDirecteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OptionalDirectedID,CourseID,DirectedSlotID")] OptionalDirected optionalDirected)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionalDirected).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", optionalDirected.CourseID);
            ViewBag.DirectedSlotID = new SelectList(db.DirectedSlots, "DirectedSlotID", "rule", optionalDirected.DirectedSlotID);
            return View(optionalDirected);
        }

        // GET: OptionalDirecteds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalDirected optionalDirected = db.Directeds.Find(id);
            if (optionalDirected == null)
            {
                return HttpNotFound();
            }
            return View(optionalDirected);
        }

        // POST: OptionalDirecteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionalDirected optionalDirected = db.Directeds.Find(id);
            db.Directeds.Remove(optionalDirected);
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
