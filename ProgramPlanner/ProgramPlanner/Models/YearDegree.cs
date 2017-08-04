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

        public string YearDegreeName { get; set; }

        public DateTime Year { get; set; }

        public int DegreeID { get; set; }
        public Degree Degree { get; set; }

        public virtual List<Major> Majors { get; set; }

        public virtual List<DegreeCore> DegreeCores { get; set; }

        public virtual List<DegreeCoreSlot> DegreeCoreSlots { get; set; }

    }
}