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
    public class SemesterCourse
    {
        public int SemesterID { get; set; }

        public Semester Semester { get; set; }

        public int CourseID { get; set; }

        public Course Course { get; set; }

        [Range(1900, 9999, ErrorMessage = "Must be between 1900, and 9999")]
        public int Year { get; set; }
    }
}