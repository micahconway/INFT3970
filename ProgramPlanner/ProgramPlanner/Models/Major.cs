using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Major
    {
        public int MajorID { get; set; }

        public string MajorName { get; set; }

        public int YearDegreeID { get; set; }
        public YearDegree YearDegree { get; set; }
    }
}