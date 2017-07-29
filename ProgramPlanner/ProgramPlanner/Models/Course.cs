using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramPlanner.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public int MyProperty { get; set; }

        public int Units { get; set; }

        public int UniversityID { get; set; }
        public University University { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}