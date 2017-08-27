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
    public class StudyAreasController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: StudyAreas
        public ActionResult Index()
        {
            var studyAreas = db.StudyAreas.Include(s => s.University);
            return View(studyAreas.ToList());
        }

        // GET: StudyAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudyArea studyArea = db.StudyAreas
                .Include(sa => sa.University)
                .SingleOrDefault(sa => sa.StudyAreaID == id);

            if (studyArea == null)
            {
                return HttpNotFound();
            }
            return View(studyArea);
        }

        // GET: StudyAreas/Create
        public ActionResult Create()
        {
            ViewBag.UniversityID = new SelectList(db.Universities, "UniversityID", "UniName");
            return View();
        }

        // POST: StudyAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudyAreaID,StudyAreaName,UniversityID")] StudyArea studyArea)
        {
            if (ModelState.IsValid)
            {
                db.StudyAreas.Add(studyArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UniversityID = new SelectList(db.Universities, "UniversityID", "UniName", studyArea.UniversityID);
            return View(studyArea);
        }

        // GET: StudyAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyArea studyArea = db.StudyAreas.Find(id);
            if (studyArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversityID = new SelectList(db.Universities, "UniversityID", "UniName", studyArea.UniversityID);
            return View(studyArea);
        }

        // POST: StudyAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudyAreaID,StudyAreaName,UniversityID")] StudyArea studyArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UniversityID = new SelectList(db.Universities, "UniversityID", "UniName", studyArea.UniversityID);
            return View(studyArea);
        }

        // GET: StudyAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyArea studyArea = db.StudyAreas
                .Include(sa => sa.University)
                .SingleOrDefault(sa => sa.StudyAreaID == id);

            if (studyArea == null)
            {
                return HttpNotFound();
            }
            return View(studyArea);
        }

        // POST: StudyAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyArea studyArea = db.StudyAreas.Find(id);
            db.StudyAreas.Remove(studyArea);
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
