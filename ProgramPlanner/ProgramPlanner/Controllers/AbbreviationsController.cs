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
    public class AbbreviationsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Abbreviations
        public ActionResult Index()
        {
            var abbreviations = db.Abbreviations.Include(a => a.StudyArea);
            return View(abbreviations.ToList());
        }

        // GET: Abbreviations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbreviation abbreviation = db.Abbreviations.Find(id);
            if (abbreviation == null)
            {
                return HttpNotFound();
            }
            return View(abbreviation);
        }

        // GET: Abbreviations/Create
        public ActionResult Create()
        {
            ViewBag.StudyAreaID = new SelectList(db.StudyAreas, "StudyAreaID", "StudyAreaName");
            return View();
        }

        // POST: Abbreviations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AbbreviationID,AbbrevName,StudyAreaID")] Abbreviation abbreviation)
        {
            if (ModelState.IsValid)
            {
                db.Abbreviations.Add(abbreviation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudyAreaID = new SelectList(db.StudyAreas, "StudyAreaID", "StudyAreaName", abbreviation.StudyAreaID);
            return View(abbreviation);
        }

        // GET: Abbreviations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbreviation abbreviation = db.Abbreviations.Find(id);
            if (abbreviation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudyAreaID = new SelectList(db.StudyAreas, "StudyAreaID", "StudyAreaName", abbreviation.StudyAreaID);
            return View(abbreviation);
        }

        // POST: Abbreviations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AbbreviationID,AbbrevName,StudyAreaID")] Abbreviation abbreviation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abbreviation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudyAreaID = new SelectList(db.StudyAreas, "StudyAreaID", "StudyAreaName", abbreviation.StudyAreaID);
            return View(abbreviation);
        }

        // GET: Abbreviations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abbreviation abbreviation = db.Abbreviations.Find(id);
            if (abbreviation == null)
            {
                return HttpNotFound();
            }
            return View(abbreviation);
        }

        // POST: Abbreviations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abbreviation abbreviation = db.Abbreviations.Find(id);
            db.Abbreviations.Remove(abbreviation);
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
