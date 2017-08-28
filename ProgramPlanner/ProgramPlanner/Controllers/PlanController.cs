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
            Setup.InitializeCourseCode(db);

            ViewBag.UnitsPerDegree = 240;
            ViewBag.SubjectsPerSemester = 4;

            //courses to be searched for in the search box
            List<String> courseCodes = new List<String>();
            foreach (var item in db.Courses)
            {
                courseCodes.Add(item.CourseCode);
            }
            ViewBag.CourseCodeList = courseCodes;

            //ViewBag.Directeds = new SelectList(db.Courses, "CourseID", "CourseCode");

            //YearDegree yearDegree = db.YearDegrees.Find("1");            
            //ViewBag.YearDegreeSelected = "";
            //ViewBag.DegreeCoreCourses = 

            
            return View(db.StudyAreas.ToList());
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