using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class YearDegree
    {

        public int yearDegreeID { get; set; }

        public DateTime Year { get; set; }

        public int DegreeID { get; set; }

        public Degree Degree { get; set; }
    }
}