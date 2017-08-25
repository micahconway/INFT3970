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
    public class YearDegreesController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: YearDegrees
        public ActionResult Index()
        {
            var yearDegrees = db.YearDegrees.Include(y => y.Degree);
            return View(yearDegrees.ToList());
        }

        // GET: YearDegrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearDegree yearDegree = db.YearDegrees.Find(id);
            if (yearDegree == null)
            {
                return HttpNotFound();
            }
            return View(yearDegree);
        }

        // GET: YearDegrees/Create
        public ActionResult Create()
        {
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeName");
            return View();
        }

        // POST: YearDegrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearDegreeID,Year,DegreeID,Units")] YearDegree yearDegree)
        {
            if (ModelState.IsValid)
            {
                db.YearDegrees.Add(yearDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeName", yearDegree.DegreeID);
            return View(yearDegree);
        }

        // GET: YearDegrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearDegree yearDegree = db.YearDegrees.Find(id);
            if (yearDegree == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeName", yearDegree.DegreeID);
            return View(yearDegree);
        }

        // POST: YearDegrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearDegreeID,Year,DegreeID,Units")] YearDegree yearDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeName", yearDegree.DegreeID);
            return View(yearDegree);
        }

        // GET: YearDegrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearDegree yearDegree = db.YearDegrees.Find(id);
            if (yearDegree == null)
            {
                return HttpNotFound();
            }
            return View(yearDegree);
        }

        // POST: YearDegrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearDegree yearDegree = db.YearDegrees.Find(id);
            db.YearDegrees.Remove(yearDegree);
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
