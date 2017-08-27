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
    public class DegreeCoreSlot
    {
        public int DegreeCoreSlotID { get; set; }

        public int numOfOptions { get; set; }

        public virtual ICollection<OptionalCoreCourse> OptionalCoreCourses { get; set; }

        public virtual YearDegree YearDegree { get; set; }
    }
}