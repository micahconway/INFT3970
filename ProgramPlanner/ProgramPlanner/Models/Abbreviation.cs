<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Abbreviation
    {
        public int AbbreviationID { get; set; }
        public string AbbrevName { get; set; }
        public int StudyAreaID { get; set; }
        public virtual StudyArea StudyArea { get; set; }
        public virtual ICollection<Course> Courses{get;set;}
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Abbreviation
    {
        public int AbbreviationID { get; set; }

        public string AbbrevName { get; set; }

        public int StudyAreaID { get; set; }

        public virtual StudyArea StudyArea { get; set; }

        public virtual ICollection<Course> Courses{get;set;}
    }
>>>>>>> Stashed changes
}