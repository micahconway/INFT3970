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
    public class DegreeCoreSlotsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: DegreeCoreSlots
        public ActionResult Index()
        {
            return View(db.DegreeCoreSlots.ToList());
        }

        // GET: DegreeCoreSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCoreSlot degreeCoreSlot = db.DegreeCoreSlots.Find(id);
            if (degreeCoreSlot == null)
            {
                return HttpNotFound();
            }
            return View(degreeCoreSlot);
        }

        // GET: DegreeCoreSlots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DegreeCoreSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeCoreSlotID,numOfOptions")] DegreeCoreSlot degreeCoreSlot)
        {
            if (ModelState.IsValid)
            {
                db.DegreeCoreSlots.Add(degreeCoreSlot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degreeCoreSlot);
        }

        // GET: DegreeCoreSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCoreSlot degreeCoreSlot = db.DegreeCoreSlots.Find(id);
            if (degreeCoreSlot == null)
            {
                return HttpNotFound();
            }
            return View(degreeCoreSlot);
        }

        // POST: DegreeCoreSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeCoreSlotID,numOfOptions")] DegreeCoreSlot degreeCoreSlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeCoreSlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degreeCoreSlot);
        }

        // GET: DegreeCoreSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeCoreSlot degreeCoreSlot = db.DegreeCoreSlots.Find(id);
            if (degreeCoreSlot == null)
            {
                return HttpNotFound();
            }
            return View(degreeCoreSlot);
        }

        // POST: DegreeCoreSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeCoreSlot degreeCoreSlot = db.DegreeCoreSlots.Find(id);
            db.DegreeCoreSlots.Remove(degreeCoreSlot);
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
