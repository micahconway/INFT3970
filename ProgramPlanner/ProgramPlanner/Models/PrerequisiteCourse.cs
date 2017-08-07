using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class PrerequisiteCourse
    {
        public int PrerequisiteCourseID { get; set; }

        public int RequiredCourseID { get; set; }

        public virtual Course RequiredCourse { get; set; }

        public int PrerequisiteID { get; set; }

        public virtual Course Prerequisite { get; set; }
    }
}