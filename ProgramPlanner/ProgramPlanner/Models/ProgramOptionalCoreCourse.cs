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
    public class ProgramOptionalCoreCourse
    {
        public int ProgramOptionalCoreCourseID { get; set; }

        public int ProgramStructureID { get; set; }

        public virtual ProgramStructure ProgramStructure { get; set; }

        public int OptionalCoreID { get; set; }

        public virtual OptionalCoreCourse OptionalCoreCourse { get; set; }
    }
}