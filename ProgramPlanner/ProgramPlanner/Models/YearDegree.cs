using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramPlanner.Models
{
    public class YearDegree
    {

        public int YearDegreeID { get; set; }

        public int Year { get; set; }

        public int DegreeID { get; set; }

        public virtual Degree Degree { get; set; }

        public int Units { get; set; }

        public virtual ICollection<Major> Majors { get; set; }

        public virtual ICollection<DegreeCore> DegreeCores { get; set; }

        public virtual ICollection<DegreeCoreSlot> DegreeCoreSlots { get; set; }

        public virtual ICollection<Replacement> Replacements { get; set; }

    }
}