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
    public class ProgramMajor
    {
        public int ProgramMajorID { get; set; }

        public int ProgramStructureID { get; set; }

        public virtual ProgramStructure ProgramStructure { get; set; }

        public int MajorID { get; set; }

        public virtual Major Major { get; set;}
    }
}