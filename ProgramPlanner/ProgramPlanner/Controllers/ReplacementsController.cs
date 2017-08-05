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
    public class ReplacementsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Replacements
        public ActionResult Index()
        {
            return View(db.Replacements.ToList());
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
            return View();
        }

        // POST: Replacements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplacementID,ReplacementCourseID,ReplacedCourseID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Replacements.Add(replacement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(replacement);
        }

        // POST: Replacements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplacementID,ReplacementCourseID,ReplacedCourseID")] Replacement replacement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replacement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
