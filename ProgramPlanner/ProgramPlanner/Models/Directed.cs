using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Directed : Course
    {
        public int MajorID { get; set; }
        public virtual Major Major { get; set; }
    }
}