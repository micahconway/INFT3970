using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramPlanner.Models
{
    //A course requires a prerequisite in order to be done, this is that prerequisite.
    public class NeededPrereq
    {
        public int NeededPrereqID { get; set; }

        public string NeededPrereqName { get; set; }

        public int Course { get; set; }
        public virtual Course RequiredCourse { get; set; }
        
        public int PrerequisiteCourseID { get; set; } 
        public virtual PrerequisiteCourse PrerequisiteCourse { get; set; }

        
    }
}