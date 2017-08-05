using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Author: Ryan Cunneen
/// Date created: 05-Aug-2017
/// Date Modified: 05-Aug-2017
/// </summary>
namespace ProgramPlanner.Models
{
    public class Semester
    {
        public int SemesterID { get; set; }

        [Required]
        public int SemesterValue { get; set; }
    }
}