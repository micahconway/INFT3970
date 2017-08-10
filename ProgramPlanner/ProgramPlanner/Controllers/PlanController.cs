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
        // GET: Plan
        public ActionResult Index()
        {
            ViewBag.YearsInDegree = 3;
            ViewBag.SubjectsPerSemester = 4;
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(Plan plan)
        {
            string blah = plan.InputData;
            return View();
        }
    }
}