using ProgramPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Controllers
{
    public static class Setup
    {
        // Initializes the data for the CourseCode for each Course in the database.
        // But doesn't store the data into the database.
        public static void InitializeCourseCode(ProgramPlannerContext db)
        {
            foreach (Course course in db.Courses)
            {
                course.CourseCode = course.Abbreviation.AbbrevName + course.Code;
            }
        }
    }
}