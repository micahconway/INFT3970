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
    public class ProgramElective
    {
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public int ProgramStructureID { get; set; }

        public virtual ProgramStructure ProgramStructure { get; set; }

        public int Completed { get; set; }
    }
}