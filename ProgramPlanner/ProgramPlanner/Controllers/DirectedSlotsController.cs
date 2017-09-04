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
    public class DirectedSlotsController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: DirectedSlots
        public ActionResult Index()
        {
            var directedSlots = db.DirectedSlots.Include(d => d.Major);
            return View(directedSlots.ToList());
        }

        // GET: DirectedSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectedSlot directedSlot = db.DirectedSlots.Find(id);
            if (directedSlot == null)
            {
                return HttpNotFound();
            }
            return View(directedSlot);
        }

        // GET: DirectedSlots/Create
        public ActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // POST: DirectedSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectedSlotID,rule,MajorID")] DirectedSlot directedSlot)
        {
            if (ModelState.IsValid)
            {
                db.DirectedSlots.Add(directedSlot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directedSlot.MajorID);
            return View(directedSlot);
        }

        // GET: DirectedSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectedSlot directedSlot = db.DirectedSlots.Find(id);
            if (directedSlot == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directedSlot.MajorID);
            return View(directedSlot);
        }

        // POST: DirectedSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectedSlotID,rule,MajorID")] DirectedSlot directedSlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directedSlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", directedSlot.MajorID);
            return View(directedSlot);
        }

        // GET: DirectedSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectedSlot directedSlot = db.DirectedSlots.Find(id);
            if (directedSlot == null)
            {
                return HttpNotFound();
            }
            return View(directedSlot);
        }

        // POST: DirectedSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectedSlot directedSlot = db.DirectedSlots.Find(id);
            db.DirectedSlots.Remove(directedSlot);
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
