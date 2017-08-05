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
    public class OptionalCoreCoursesController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: OptionalCoreCourses
        public ActionResult Index()
        {
            var optionalCoreCourses = db.OptionalCoreCourses.Include(o => o.Course).Include(o => o.DegreeCoreSlot);
            return View(optionalCoreCourses.ToList());
        }

        // GET: OptionalCoreCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalCoreCourse optionalCoreCourse = db.OptionalCoreCourses.Find(id);
            if (optionalCoreCourse == null)
            {
                return HttpNotFound();
            }
            return View(optionalCoreCourse);
        }

        // GET: OptionalCoreCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.DegreeCoreSlotID = new SelectList(db.DegreeCoreSlots, "DegreeCoreSlotID", "DegreeCoreSlotID");
            return View();
        }

        // POST: OptionalCoreCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OptionalCoreCourseID,DegreeCoreSlotID,CourseID")] OptionalCoreCourse optionalCoreCourse)
        {
            if (ModelState.IsValid)
            {
                db.OptionalCoreCourses.Add(optionalCoreCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", optionalCoreCourse.CourseID);
            ViewBag.DegreeCoreSlotID = new SelectList(db.DegreeCoreSlots, "DegreeCoreSlotID", "DegreeCoreSlotID", optionalCoreCourse.DegreeCoreSlotID);
            return View(optionalCoreCourse);
        }

        // GET: OptionalCoreCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalCoreCourse optionalCoreCourse = db.OptionalCoreCourses.Find(id);
            if (optionalCoreCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", optionalCoreCourse.CourseID);
            ViewBag.DegreeCoreSlotID = new SelectList(db.DegreeCoreSlots, "DegreeCoreSlotID", "DegreeCoreSlotID", optionalCoreCourse.DegreeCoreSlotID);
            return View(optionalCoreCourse);
        }

        // POST: OptionalCoreCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OptionalCoreCourseID,DegreeCoreSlotID,CourseID")] OptionalCoreCourse optionalCoreCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionalCoreCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", optionalCoreCourse.CourseID);
            ViewBag.DegreeCoreSlotID = new SelectList(db.DegreeCoreSlots, "DegreeCoreSlotID", "DegreeCoreSlotID", optionalCoreCourse.DegreeCoreSlotID);
            return View(optionalCoreCourse);
        }

        // GET: OptionalCoreCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalCoreCourse optionalCoreCourse = db.OptionalCoreCourses.Find(id);
            if (optionalCoreCourse == null)
            {
                return HttpNotFound();
            }
            return View(optionalCoreCourse);
        }

        // POST: OptionalCoreCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionalCoreCourse optionalCoreCourse = db.OptionalCoreCourses.Find(id);
            db.OptionalCoreCourses.Remove(optionalCoreCourse);
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
