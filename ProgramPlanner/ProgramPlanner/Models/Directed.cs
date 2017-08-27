using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Directed
    {
        public int DirectedID { get; set; }

        public virtual Course Course { get; set; }

        public int MajorID { get; set; }

        public virtual Major Major { get; set; }

        public virtual ICollection<ProgramDirected> ProgramDirecteds { get; set; }
    }
}