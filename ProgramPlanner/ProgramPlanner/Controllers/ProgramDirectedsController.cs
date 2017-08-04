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
    public class ProgramDirectedsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: ProgramDirecteds
        public ActionResult Index()
        {
            var programDirecteds = db.ProgramDirecteds.Include(p => p.Course).Include(p => p.ProgramStructure);
            return View(programDirecteds.ToList());
        }

        // GET: ProgramDirecteds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramDirected programDirected = db.ProgramDirecteds.Find(id);
            if (programDirected == null)
            {
                return HttpNotFound();
            }
            return View(programDirected);
        }

        // GET: ProgramDirecteds/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.ProgramStructureID = new SelectList(db.ProgramStructures, "ProgramStructureID", "ProgramStructureID");
            return View();
        }

        // POST: ProgramDirecteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramDirectedID,ProgramStructureID,CourseID")] ProgramDirected programDirected)
        {
            if (ModelState.IsValid)
            {
                db.ProgramDirecteds.Add(programDirected);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", programDirected.CourseID);
            ViewBag.ProgramStructureID = new SelectList(db.ProgramStructures, "ProgramStructureID", "ProgramStructureID", programDirected.ProgramStructureID);
            return View(programDirected);
        }

        // GET: ProgramDirecteds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramDirected programDirected = db.ProgramDirecteds.Find(id);
            if (programDirected == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", programDirected.CourseID);
            ViewBag.ProgramStructureID = new SelectList(db.ProgramStructures, "ProgramStructureID", "ProgramStructureID", programDirected.ProgramStructureID);
            return View(programDirected);
        }

        // POST: ProgramDirecteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramDirectedID,ProgramStructureID,CourseID")] ProgramDirected programDirected)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programDirected).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", programDirected.CourseID);
            ViewBag.ProgramStructureID = new SelectList(db.ProgramStructures, "ProgramStructureID", "ProgramStructureID", programDirected.ProgramStructureID);
            return View(programDirected);
        }

        // GET: ProgramDirecteds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramDirected programDirected = db.ProgramDirecteds.Find(id);
            if (programDirected == null)
            {
                return HttpNotFound();
            }
            return View(programDirected);
        }

        // POST: ProgramDirecteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramDirected programDirected = db.ProgramDirecteds.Find(id);
            db.ProgramDirecteds.Remove(programDirected);
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
