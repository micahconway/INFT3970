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
    public class PlanController : Controller
    {
        private ProgramPlannerContext db = new ProgramPlannerContext();

        // GET: Plan
        public ActionResult Index()
        {
            ViewBag.YearsInDegree = 3;
            ViewBag.SubjectsPerSemester = 4;

            //YearDegree yearDegree = db.YearDegrees.Find("1");            
            //ViewBag.YearDegreeSelected = "";
            //ViewBag.DegreeCoreCourses = 

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "InputData")]Plan plan)
        {
            string blah = plan.InputData;
            return View();
        }
    }
}