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
    public class User
    {
        public int UserID { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}