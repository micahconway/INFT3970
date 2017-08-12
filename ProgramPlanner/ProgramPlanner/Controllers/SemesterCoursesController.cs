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
    public class SemesterCoursesController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: SemesterCourses
        public ActionResult Index()
        {
            var semesterCourses = db.SemesterCourses.Include(s => s.Course).Include(s => s.Semester);
            return View(semesterCourses.ToList());
        }

        // GET: SemesterCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterCourse semesterCourse = db.SemesterCourses.Find(id);
            if (semesterCourse == null)
            {
                return HttpNotFound();
            }
            return View(semesterCourse);
        }

        // GET: SemesterCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterID");
            return View();
        }

        // POST: SemesterCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterCourseID,Year,SemesterID,CourseID")] SemesterCourse semesterCourse)
        {
            if (ModelState.IsValid)
            {
                db.SemesterCourses.Add(semesterCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semesterCourse.CourseID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterID", semesterCourse.SemesterID);
            return View(semesterCourse);
        }

        // GET: SemesterCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterCourse semesterCourse = db.SemesterCourses.Find(id);
            if (semesterCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semesterCourse.CourseID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterID", semesterCourse.SemesterID);
            return View(semesterCourse);
        }

        // POST: SemesterCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterCourseID,Year,SemesterID,CourseID")] SemesterCourse semesterCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semesterCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semesterCourse.CourseID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "SemesterID", semesterCourse.SemesterID);
            return View(semesterCourse);
        }

        // GET: SemesterCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SemesterCourse semesterCourse = db.SemesterCourses.Find(id);
            if (semesterCourse == null)
            {
                return HttpNotFound();
            }
            return View(semesterCourse);
        }

        // POST: SemesterCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SemesterCourse semesterCourse = db.SemesterCourses.Find(id);
            db.SemesterCourses.Remove(semesterCourse);
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
