using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Author: Ryan Cunneen
/// Date created: 04-Aug-2017
/// Date Modified: 04-Aug-2017
/// </summary>
namespace ProgramPlanner.Models
{
    public class OptionalCoreCourse
    {
        public int OptionalCoreCourseID { get; set; }

        public int DegreeCoreSlotID { get; set; }

        public virtual DegreeCoreSlot DegreeCoreSlot { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<ProgramOptionalCoreCourse> ProgramOptionalCoreCourse { get; set; }
    }
}