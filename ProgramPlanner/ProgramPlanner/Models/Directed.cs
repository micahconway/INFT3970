using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Directed
    {
        public int DirectedID { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int MajorID { get; set; }
        public virtual Major Major { get; set; }
    }
}