using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class StudyArea
    {
        public int StudyAreaID { get; set; }

        public string StudyAreaName { get; set; }

        public int UniversityID { get; set; }

        public University University { get; set; }

        public virtual ICollection<Abbreviation> Abbrevations { get; set; }

    }
}