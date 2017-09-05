<<<<<<< Updated upstream
﻿using System;
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
        public string UniName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<StudyArea> StudyAreas { get; set; }
    }
=======
﻿using System;
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

        public string UniName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Degree> Degrees { get; set; }

        public virtual ICollection<StudyArea> StudyAreas { get; set; }
    }
>>>>>>> Stashed changes
}