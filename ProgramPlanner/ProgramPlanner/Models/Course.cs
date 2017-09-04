using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public int Code { get; set; }
        public string CourseCode{ get; set; }
        public string CourseName { get; set; }
        public int Units { get; set; }
        public string Information { get; set; }
        public int UniversityID { get; set; }
        public virtual University University { get; set; }
        public int AbbreviationID { get; set; }
        public virtual Abbreviation Abbreviation { get; set; }
        public int? ReplacementID { get; set; }
        public virtual Replacement Replacement { get; set; }
        // These are your 'AND' prerequisites. A Course can one-to-many mandatory prerequisites. 
        public virtual ICollection<Course> MandatoryPrerequisites { get; set; }
        // These are your 'OR' prerequisites. A Course can have zero-to-many optional prerequisites. 
        public virtual ICollection<Course> OptionalPrerequisites { get; set; }
        public virtual ICollection<ProgramElective> ProgramElectives { get; set; }
        public virtual ICollection<MajorCore> MajorCores { get; set; }
        public virtual ICollection<DegreeCore> DegreeCores { get; set; }
        public virtual ICollection<TrimesterCourse> TrimesterCourses { get; set; }
        public virtual ICollection<SemesterCourse> SemesterCourses { get; set; }
<<<<<<< HEAD


        // public virtual Replacement Replacement { get; set; }

        public virtual ICollection<Directed> Directeds { get; set; }

=======
        public virtual ICollection<OptionalCoreCourse> OptionalCoreCourses { get; set; }
        public virtual ICollection<OptionalDirected> OptionalDirecteds { get; set; }
>>>>>>> 3de65001a3a88a7b9ea8a6b81b26a8b20a4bc211
    }
}