using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace ProgramPlanner.Models
{
    public class ProgramPlannerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ProgramPlannerContext() : base("name=ProgramPlannerContext")
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<YearDegree> YearDegrees { get; set; }

<<<<<<< HEAD
        public DbSet<Degree> Degrees { get; set; }
=======
        public System.Data.Entity.DbSet<ProgramPlanner.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.Major> Majors { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.University> Universities { get; set; }
>>>>>>> b303bae991ff5189dd3d4eed3ffd15cd836c7792
    }
}
