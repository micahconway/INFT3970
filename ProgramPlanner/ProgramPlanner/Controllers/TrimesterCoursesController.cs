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
    public class TrimesterCoursesController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: TrimesterCourses
        public ActionResult Index()
        {
            // Setup up the data for course codes.
            Setup.InitializeCourseCode(db);

            var trimesterCourses = db.TrimesterCourses.Include(t => t.Course).Include(t => t.Trimester);

            return View(trimesterCourses.ToList());
        }

        // GET: TrimesterCourses/Details/5
        public ActionResult Details(int? TrimesterID, int? CourseID)
        {
            if (TrimesterID == null || CourseID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Setup up the data for course codes.
            Setup.InitializeCourseCode(db);

            TrimesterCourse trimesterCourse = db.TrimesterCourses
                .Include(s => s.Course)
                .Include(s => s.Trimester)
                .SingleOrDefault(tc => tc.TrimesterID == TrimesterID && tc.CourseID == CourseID);

            if (trimesterCourse == null)
            {
                return HttpNotFound();
            }
            return View(trimesterCourse);
        }

        // GET: TrimesterCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TrimesterID = new SelectList(db.Trimesters, "TrimesterID", "TrimesterID");
            return View();
        }

        // POST: TrimesterCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrimesterID,CourseID,Year")] TrimesterCourse trimesterCourse)
        {
            if (ModelState.IsValid)
            {
                db.TrimesterCourses.Add(trimesterCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", trimesterCourse.CourseID);
            ViewBag.TrimesterID = new SelectList(db.Trimesters, "TrimesterID", "TrimesterID", trimesterCourse.TrimesterID);
            return View(trimesterCourse);
        }

        // GET: TrimesterCourses/Edit/5
        public ActionResult Edit(int? TrimesterID, int? CourseID)
        {
            if (TrimesterID == null || CourseID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Setup up the data for course codes.
            Setup.InitializeCourseCode(db);

            TrimesterCourse trimesterCourse = db.TrimesterCourses
                .Include(s => s.Course)
                .Include(s => s.Trimester)
                .SingleOrDefault(tc => tc.TrimesterID == TrimesterID && tc.CourseID == CourseID);

            if (trimesterCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", trimesterCourse.CourseID);
            ViewBag.TrimesterID = new SelectList(db.Trimesters, "TrimesterID", "TrimesterID", trimesterCourse.TrimesterID);
            return View(trimesterCourse);
        }

        // POST: TrimesterCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrimesterID,CourseID,Year")] TrimesterCourse trimesterCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimesterCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", trimesterCourse.CourseID);
            ViewBag.TrimesterID = new SelectList(db.Trimesters, "TrimesterID", "TrimesterID", trimesterCourse.TrimesterID);
            return View(trimesterCourse);
        }

        // GET: TrimesterCourses/Delete/5
        public ActionResult Delete(int? TrimesterID, int? CourseID)
        {
            if (TrimesterID == null || CourseID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Setup up the data for course codes.
            Setup.InitializeCourseCode(db);

            TrimesterCourse trimesterCourse = db.TrimesterCourses
                .Include(s => s.Course)
                .Include(s => s.Trimester)
                .SingleOrDefault(tc => tc.TrimesterID == TrimesterID && tc.CourseID == CourseID);

            if (trimesterCourse == null)
            {
                return HttpNotFound();
            }
            return View(trimesterCourse);
        }

        // POST: TrimesterCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? TrimesterID, int? CourseID)
        {
            TrimesterCourse trimesterCourse = db.TrimesterCourses
            .Include(s => s.Course)
            .Include(s => s.Trimester)
            .SingleOrDefault(tc => tc.TrimesterID == TrimesterID && tc.CourseID == CourseID);

            db.TrimesterCourses.Remove(trimesterCourse);
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
