using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramPlanner.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}