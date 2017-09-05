<<<<<<< Updated upstream
﻿using System;
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
    public class ReplacementsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Replacements
        public ActionResult Index()
        {
            List<Test> replacementList = Setup.InitializeReplacements(db);
            Setup.InitializeCourseCode(db);
            return View(replacementList.ToList());
        }

        // GET: Replacements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            return View(replacement);
        }

        // GET: Replacements/Create
        public ActionResult Create()
        {
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID");
            return View();
        }

        // POST: Replacements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplacementID,YearDegreeID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Replacements.Add(replacement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // GET: Replacements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // POST: Replacements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplacementID,YearDegreeID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replacement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // GET: Replacements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            return View(replacement);
        }

        // POST: Replacements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Replacement replacement = db.Replacements.Find(id);
            db.Replacements.Remove(replacement);
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
=======
﻿using System;
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
    public class ReplacementsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Replacements
        public ActionResult Index()
        {
            //var replacements = db.Replacements.Include(r => r.ReplacementCourse).Include(r => r.YearDegree);
            var replacements = 
                (from c in db.Courses
                    join r in db.Replacements
                        on c.CourseID equals r.ReplacementID
                 select new { c.CourseCode, r.ReplacementCourse.CourseID});
            return View(replacements.ToList());
        }

        // GET: Replacements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            return View(replacement);
        }

        // GET: Replacements/Create
        public ActionResult Create()
        {
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID");
            return View();
        }

        // POST: Replacements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplacementID,YearDegreeID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Replacements.Add(replacement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // GET: Replacements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // POST: Replacements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplacementID,YearDegreeID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replacement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReplacementID = new SelectList(db.Courses, "CourseID", "CourseName", replacement.ReplacementID);
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeID", replacement.YearDegreeID);
            return View(replacement);
        }

        // GET: Replacements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Replacement replacement = db.Replacements.Find(id);
            if (replacement == null)
            {
                return HttpNotFound();
            }
            return View(replacement);
        }

        // POST: Replacements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Replacement replacement = db.Replacements.Find(id);
            db.Replacements.Remove(replacement);
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
>>>>>>> Stashed changes
