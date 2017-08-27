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
    public class User
    {
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name ="Password")]
        public string Password { get; set; }

        public virtual ICollection<ProgramStructure> ProgramStructures { get; set; }
    }
}