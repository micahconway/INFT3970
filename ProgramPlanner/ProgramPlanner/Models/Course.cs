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
        [MaxLength(8)]
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

        // These are your 'AND' prerequisites.
        // A Course can one-to-many mandatory prerequisites. 
        public virtual ICollection<Course> MandatoryPrerequisites { get; set; }

        // These are your 'OR' prerequisites
        // A Course can have zero-to-many optional prerequisites. 
        public virtual ICollection<Course> OptionalPrerequisites { get; set; }
    }
}