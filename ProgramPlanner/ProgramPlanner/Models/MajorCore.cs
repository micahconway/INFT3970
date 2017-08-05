using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class MajorCore
    {
        public int MajorCoreID { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public int MajorID { get; set; }

        public virtual Major Major { get; set; }

    }
}