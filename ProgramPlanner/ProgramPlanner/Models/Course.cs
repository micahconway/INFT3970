using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        [Range(10, 20)]
        public int Units { get; set; }

        public int UniversityID { get; set; }

        public virtual University University { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        //This course many have one or many courses it can be a prerequisite for.
        public virtual List<PrerequisiteCourse> PrerequisiteCourses { get; set; }

        //A course may need one or many prerequisites in order to be studied.
        public virtual List<NeededPrereq> NeededPrereqs { get; set; }

    }
}