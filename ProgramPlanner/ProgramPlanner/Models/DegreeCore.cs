using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class DegreeCore
    {
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public int YearDegreeID { get; set; }
        public virtual YearDegree YearDegree { get; set; }
    }
}