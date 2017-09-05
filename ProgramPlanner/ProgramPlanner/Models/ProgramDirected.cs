﻿using System;
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
    public class ProgramDirected
    {
        public int ProgramStructureID { get; set; }
        public virtual ProgramStructure ProgramStructure { get; set; }
        public int OptionalDirectedID { get; set; }
        public virtual OptionalDirected OptionalDirected { get; set; }
        public int Completed { get; set; }
    }
}