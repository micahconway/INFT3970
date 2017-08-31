using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class DirectedSlot
    {
        public int DirectedSlotID { get; set; }
        public string rule { get; set; }
        // Didn't change the name of Directed to Optional Directed as it may corrupt the application.
        public virtual ICollection<OptionalDirected> OptionalDirecteds {get;set;}
        public int MajorID { get; set; }
        public virtual Major Major { get; set; }
    }
}