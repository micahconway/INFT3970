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
    public class ProgramStructuresController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: ProgramStructures
        public ActionResult Index()
        {
            var programStructures = db.ProgramStructures.Include(ps => ps.User);
            return View(programStructures.ToList());
        }

        // GET: ProgramStructures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramStructure programStructure = db.ProgramStructures.Find(id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }
            return View(programStructure);
        }

        // GET: ProgramStructures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramStructures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramStructureID,DateCreated,DateModified,UserID")] ProgramStructure programStructure)
        {
            if (ModelState.IsValid)
            {
                db.ProgramStructures.Add(programStructure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programStructure);
        }

        // GET: ProgramStructures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramStructure programStructure = db.ProgramStructures.Find(id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }
            return View(programStructure);
        }

        // POST: ProgramStructures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramStructureID,DateCreated,DateModified,UserID")] ProgramStructure programStructure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programStructure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programStructure);
        }

        // GET: ProgramStructures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramStructure programStructure = db.ProgramStructures.Find(id);
            if (programStructure == null)
            {
                return HttpNotFound();
            }
            return View(programStructure);
        }

        // POST: ProgramStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramStructure programStructure = db.ProgramStructures.Find(id);
            db.ProgramStructures.Remove(programStructure);
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
