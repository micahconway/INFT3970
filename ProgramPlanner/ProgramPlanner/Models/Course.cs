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

        [MaxLength(8)]
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        [Range(10, 20)]
        public int Units { get; set; }

        public int UniversityID { get; set; }

        public virtual University University { get; set; }

        public int AbbreviationID { get; set; }

        public virtual Abbreviation Abbreviation { get; set; }

        // These are your 'AND' prerequisites.
        // A Course can one-to-many mandatory prerequisites. 
        public virtual ICollection<Course> MandatoryPrerequisites { get; set; }

        // These are your 'OR' prerequisites
        // A Course can have zero-to-many optional prerequisites. 
        public virtual ICollection<Course> OptionalPrerequisites { get; set; }
    }
}