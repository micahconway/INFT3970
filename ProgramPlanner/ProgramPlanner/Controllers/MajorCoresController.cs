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
    public class MajorCoresController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: MajorCores
        public ActionResult Index()
        {
            var majorCores = db.MajorCores.Include(m => m.Course).Include(m => m.Major);

            // Setup up the data for course codes.
            Setup.InitializeCourseCode(db);

            return View(majorCores.ToList());
        }

        // GET: MajorCores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorCore majorCore = db.MajorCores.Find(id);
            if (majorCore == null)
            {
                return HttpNotFound();
            }
            return View(majorCore);
        }

        // GET: MajorCores/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // POST: MajorCores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,MajorID")] MajorCore majorCore)
        {
            if (ModelState.IsValid)
            {
                db.MajorCores.Add(majorCore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", majorCore.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", majorCore.MajorID);
            return View(majorCore);
        }

        // GET: MajorCores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorCore majorCore = db.MajorCores.Find(id);
            if (majorCore == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", majorCore.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", majorCore.MajorID);
            return View(majorCore);
        }

        // POST: MajorCores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,MajorID")] MajorCore majorCore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majorCore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", majorCore.CourseID);
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", majorCore.MajorID);
            return View(majorCore);
        }

        // GET: MajorCores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorCore majorCore = db.MajorCores.Find(id);
            if (majorCore == null)
            {
                return HttpNotFound();
            }
            return View(majorCore);
        }

        // POST: MajorCores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MajorCore majorCore = db.MajorCores.Find(id);
            db.MajorCores.Remove(majorCore);
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
