using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class Degree
    {
        public int DegreeID { get; set; }

        [Required]
        public string DegreeName { get; set; }

        public int UniversityID { get; set; }

        // How long the degree will take the complete (Years). 
        public int Duration { get; set; }

        public University University { get; set; }

        public virtual List<YearDegree> YearDegrees { get; set; }
    }
}