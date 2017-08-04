using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramPlanner.Models
{
    //A course is a prerequisite for another course
    public class PrerequisiteCourse
    {
        [Key, ForeignKey("NeededPrereq")]
        public int PrerequisiteCourseID { get; set; }

        public string PrerequisiteCourseName { get; set; }

        public int Course { get; set; }
        public virtual Course RequiredCourse { get; set; }
        
        public int NeededPrereqID { get; set; }
        public virtual NeededPrereq NeededPrereq { get; set; }

        
    }
}