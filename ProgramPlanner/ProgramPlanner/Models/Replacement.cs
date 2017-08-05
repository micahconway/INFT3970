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
    public class Replacement
    {
        public int ReplacementID { get; set; }

        public int? ReplacementCourseID { get; set; }

        [ForeignKey("ReplacementCourseID")]
        public Course ReplacementCourse { get; set; }

        public int? ReplacedCourseID { get; set; }

        [ForeignKey("ReplacedCourseID")]
        public Course ReplacedCourse { get; set; }
    }
}