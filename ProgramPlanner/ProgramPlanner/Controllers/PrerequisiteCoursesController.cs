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
    public class PrerequisiteCoursesController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: PrerequisiteCourses
        public ActionResult Index()
        {
            var prerequisiteCourses = db.PrerequisiteCourses.Include(p => p.Prerequisite).Include(p => p.RequiredCourse);
            return View(prerequisiteCourses.ToList());
        }

        // GET: PrerequisiteCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.PrerequisiteCourses.Find(id);
            if (prerequisiteCourse == null)
            {
                return HttpNotFound();
            }
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Create
        public ActionResult Create()
        {
            ViewBag.PrerequisiteID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.RequiredCourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            return View();
        }

        // POST: PrerequisiteCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrerequisiteCourseID,RequiredCourseID,PrerequisiteID")] PrerequisiteCourse prerequisiteCourse)
        {
            if (ModelState.IsValid)
            {
                db.PrerequisiteCourses.Add(prerequisiteCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrerequisiteID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.PrerequisiteID);
            ViewBag.RequiredCourseID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.RequiredCourseID);
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.PrerequisiteCourses.Find(id);
            if (prerequisiteCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrerequisiteID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.PrerequisiteID);
            ViewBag.RequiredCourseID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.RequiredCourseID);
            return View(prerequisiteCourse);
        }

        // POST: PrerequisiteCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrerequisiteCourseID,RequiredCourseID,PrerequisiteID")] PrerequisiteCourse prerequisiteCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prerequisiteCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrerequisiteID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.PrerequisiteID);
            ViewBag.RequiredCourseID = new SelectList(db.Courses, "CourseID", "CourseCode", prerequisiteCourse.RequiredCourseID);
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.PrerequisiteCourses.Find(id);
            if (prerequisiteCourse == null)
            {
                return HttpNotFound();
            }
            return View(prerequisiteCourse);
        }

        // POST: PrerequisiteCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrerequisiteCourse prerequisiteCourse = db.PrerequisiteCourses.Find(id);
            db.PrerequisiteCourses.Remove(prerequisiteCourse);
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
