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
            var prerequisites = db.Prerequisites.Include(p => p.NeededPrereq);
            return View(prerequisites.ToList());
        }

        // GET: PrerequisiteCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.Prerequisites.Find(id);
            if (prerequisiteCourse == null)
            {
                return HttpNotFound();
            }
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Create
        public ActionResult Create()
        {
            ViewBag.NeededPrereqID = new SelectList(db.NeededPrereqs, "NeededPrereqID", "NeededPrereqName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            return View();
        }

        // POST: PrerequisiteCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrerequisiteCourseID,Course,NeededPrereqID")] PrerequisiteCourse prerequisiteCourse)
        {
            if (ModelState.IsValid)
            {
                prerequisiteCourse = addCourseName(prerequisiteCourse);
                db.Prerequisites.Add(prerequisiteCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrerequisiteCourseID = new SelectList(db.NeededPrereqs, "NeededPrereqID", "NeededPrereqID", prerequisiteCourse.PrerequisiteCourseID);
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.Prerequisites.Find(id);
            if (prerequisiteCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrerequisiteCourseID = new SelectList(db.NeededPrereqs, "NeededPrereqID", "NeededPrereqID", prerequisiteCourse.PrerequisiteCourseID);
            return View(prerequisiteCourse);
        }

        // POST: PrerequisiteCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrerequisiteCourseID,Course,NeededPrereqID")] PrerequisiteCourse prerequisiteCourse)
        {
            if (ModelState.IsValid)
            {
                prerequisiteCourse = addCourseName(prerequisiteCourse);
                db.Entry(prerequisiteCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrerequisiteCourseID = new SelectList(db.NeededPrereqs, "NeededPrereqID", "NeededPrereqID", prerequisiteCourse.PrerequisiteCourseID);
            return View(prerequisiteCourse);
        }

        // GET: PrerequisiteCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrerequisiteCourse prerequisiteCourse = db.Prerequisites.Find(id);
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
            PrerequisiteCourse prerequisiteCourse = db.Prerequisites.Find(id);
            db.Prerequisites.Remove(prerequisiteCourse);
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

        //gets CourseCode for this prerequisite
        private PrerequisiteCourse addCourseName(PrerequisiteCourse myCourse)
        {
            Course tempCourse = db.Courses.Find(myCourse.Course);
            myCourse.PrerequisiteCourseName = tempCourse.CourseCode;
            return myCourse;
        }
        
    }
}
