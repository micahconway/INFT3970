using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Email { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProgramMajor> ProgramMajors { get; set; }
        public virtual ICollection<ProgramDirected> ProgramDirecteds { get; set; }
        public virtual ICollection<ProgramElective> ProgramElectives { get; set; }
        public virtual ICollection<ProgramOptionalCoreCourse> ProgramOptionalCores { get; set; }
    }
}