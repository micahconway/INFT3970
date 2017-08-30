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
    public class DirectedsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Directeds
        public ActionResult Index()
        {
            var directeds = db.Directeds.Include(d => d.Course).Include(d => d.Major);
            Setup.InitializeCourseCode(db);
            return View(directeds.ToList());
        }

        // GET: Directeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directed directed = db.Directeds.Find(id);
            if (directed == null)
            {
                return HttpNotFound();
            }
            return View(directed);
        }

        // GET: Directeds/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // POST: Directeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectedID,CourseID,MajorID")] Directed directed)
        {
            if (ModelState.IsValid)
            {
                db.Directeds.Add(directed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", directed.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directed.MajorID);
            return View(directed);
        }

        // GET: Directeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directed directed = db.Directeds.Find(id);
            if (directed == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", directed.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directed.MajorID);
            return View(directed);
        }

        // POST: Directeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectedID,CourseID,MajorID")] Directed directed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", directed.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directed.MajorID);
            return View(directed);
        }

        // GET: Directeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directed directed = db.Directeds.Find(id);
            if (directed == null)
            {
                return HttpNotFound();
            }
            return View(directed);
        }

        // POST: Directeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directed directed = db.Directeds.Find(id);
            db.Directeds.Remove(directed);
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
