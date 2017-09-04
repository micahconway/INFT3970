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
        public string DegreeName { get; set; }
        public int Duration { get; set; }
        public virtual int UniversityID { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<YearDegree> YearDegrees { get; set; }
    }
}