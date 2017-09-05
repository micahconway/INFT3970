<<<<<<< Updated upstream:ProgramPlanner/ProgramPlanner/Models/OptionalDirected.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class OptionalDirected
    {
        public int OptionalDirectedID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<ProgramDirected> ProgramDirecteds { get; set; }
        public int DirectedSlotID { get; set; }
        public virtual DirectedSlot DirectedSlot { get; set; }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Directed
    {
        public int DirectedID { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public int MajorID { get; set; }

        public virtual Major Major { get; set; }

        public virtual ICollection<ProgramDirected> ProgramDirecteds { get; set; }
    }
>>>>>>> Stashed changes:ProgramPlanner/ProgramPlanner/Models/Directed.cs
}