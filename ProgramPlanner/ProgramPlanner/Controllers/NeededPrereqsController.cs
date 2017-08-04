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
    public class NeededPrereqsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: NeededPrereqs
        public ActionResult Index()
        {
            var neededPrereqs = db.NeededPrereqs.Include(n => n.PrerequisiteCourse);
            return View(neededPrereqs.ToList());
        }

        // GET: NeededPrereqs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NeededPrereq neededPrereq = db.NeededPrereqs.Find(id);
            if (neededPrereq == null)
            {
                return HttpNotFound();
            }
            return View(neededPrereq);
        }

        // GET: NeededPrereqs/Create
        public ActionResult Create()
        {
            ViewBag.PrerequisiteCourseID = new SelectList(db.Prerequisites, "PrerequisiteCourseID", "PrerequisiteCourseName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            
            return View();
        }

        // POST: NeededPrereqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NeededPrereqID,Course,PrerequisiteCourseID")] NeededPrereq neededPrereq)
        {
            if (ModelState.IsValid)
            {
                neededPrereq = addCourseName(neededPrereq);
                db.NeededPrereqs.Add(neededPrereq);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NeededPrereqID = new SelectList(db.Prerequisites, "PrerequisiteCourseID", "PrerequisiteCourseID", neededPrereq.NeededPrereqID);
            return View(neededPrereq);
        }

        // GET: NeededPrereqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NeededPrereq neededPrereq = db.NeededPrereqs.Find(id);
            if (neededPrereq == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeededPrereqID = new SelectList(db.Prerequisites, "PrerequisiteCourseID", "PrerequisiteCourseID", neededPrereq.NeededPrereqID);
            return View(neededPrereq);
        }

        // POST: NeededPrereqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NeededPrereqID,Course,PrerequisiteCourseID")] NeededPrereq neededPrereq)
        {
            if (ModelState.IsValid)
            {
                neededPrereq = addCourseName(neededPrereq);
                db.Entry(neededPrereq).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NeededPrereqID = new SelectList(db.Prerequisites, "PrerequisiteCourseID", "PrerequisiteCourseID", neededPrereq.NeededPrereqID);
            return View(neededPrereq);
        }

        // GET: NeededPrereqs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NeededPrereq neededPrereq = db.NeededPrereqs.Find(id);
            if (neededPrereq == null)
            {
                return HttpNotFound();
            }
            return View(neededPrereq);
        }

        // POST: NeededPrereqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NeededPrereq neededPrereq = db.NeededPrereqs.Find(id);
            db.NeededPrereqs.Remove(neededPrereq);
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

        //gets CourseCode for this NeededPrereq
        private NeededPrereq addCourseName(NeededPrereq myNeededPrereq)
        {
            Course tempCourse = db.Courses.Find(myNeededPrereq.Course);
            myNeededPrereq.NeededPrereqName = tempCourse.CourseCode;
            return myNeededPrereq;
        }
    }
}
