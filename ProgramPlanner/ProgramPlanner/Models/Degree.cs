using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Degree
    {
        public int DegreeID { get; set; }

        public string DegreeName { get; set; }

        public virtual List<YearDegree> YearDegrees { get; set; }
    }
}