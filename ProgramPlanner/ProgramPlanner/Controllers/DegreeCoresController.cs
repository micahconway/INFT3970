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
    public class DegreeCoresController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: DegreeCores
        public ActionResult Index()
        {
            var degreeCores = db.DegreeCores.Include(d => d.Course);
            return View(degreeCores.ToList());
        }

        // GET: DegreeCores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCore degreeCore = db.DegreeCores.Find(id);
            if (degreeCore == null)
            {
                return HttpNotFound();
            }
            return View(degreeCore);
        }

        // GET: DegreeCores/Create
        public ActionResult Create()
        {
            ViewBag.YearDegreeID = new SelectList(db.YearDegrees, "YearDegreeID", "YearDegreeName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            return View();
        }

        // POST: DegreeCores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeCoreID,CourseID,YearDegreeID")] DegreeCore degreeCore)
        {
            if (ModelState.IsValid)
            {
                db.DegreeCores.Add(degreeCore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", degreeCore.CourseID);
            return View(degreeCore);
        }

        // GET: DegreeCores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCore degreeCore = db.DegreeCores.Find(id);
            if (degreeCore == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", degreeCore.CourseID);
            return View(degreeCore);
        }

        // POST: DegreeCores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeCoreID,CourseID,YearDegreeID")] DegreeCore degreeCore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeCore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", degreeCore.CourseID);
            return View(degreeCore);
        }

        // GET: DegreeCores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCore degreeCore = db.DegreeCores.Find(id);
            if (degreeCore == null)
            {
                return HttpNotFound();
            }
            return View(degreeCore);
        }

        // POST: DegreeCores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeCore degreeCore = db.DegreeCores.Find(id);
            db.DegreeCores.Remove(degreeCore);
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
