using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class University
    {
        public int UniversityID { get; set; }

        [Required]
        public string UniName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Degree> Degrees { get; set; }
    }
}