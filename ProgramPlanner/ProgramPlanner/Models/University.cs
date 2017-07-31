using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class University
    {
        public int UniversityID { get; set; }

        public string UniName { get; set; }

        public virtual List<Course> Courses { get; set; }

        public  virtual List<Degree> Degrees { get; set; }
    }
}