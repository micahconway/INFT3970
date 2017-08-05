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
        public int UserID { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "The {0} must be less than or equal to 100 in length.")]
        [MinLength(5, ErrorMessage ="Cannot be less than 5 characters.")]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}