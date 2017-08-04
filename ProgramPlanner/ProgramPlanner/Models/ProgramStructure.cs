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
    public class ProgramStructure
    {
        public int ProgramStructureID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime  DateModified { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual List<ProgramMajor> ProgramMajors { get; set; }

        public virtual List<ProgramDirected> ProgramDirected { get; set; }

        public virtual List<ProgramElective> ProgramElectives { get; set; }

        public virtual List<ProgramOptionalCoreCourse> ProgramOptionalCores { get; set; }
    }
}