<<<<<<< Updated upstream
﻿using System;
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
    public class Trimester
    {
        public int TrimesterID { get; set; }
        public int TrimesterValue { get; set; }
        public virtual ICollection<TrimesterCourse> TrimesterCourses{ get; set; }
    }
=======
﻿using System;
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
    public class Trimester
    {
        public int TrimesterID { get; set; }

        //[Range(1, 3)]
        public int TrimesterValue { get; set; }

        public virtual ICollection<TrimesterCourse> TrimesterCourses{ get; set; }
    }
>>>>>>> Stashed changes
}