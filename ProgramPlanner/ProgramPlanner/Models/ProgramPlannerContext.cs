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

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<Directed> Directeds { get; set; }

        public DbSet<MajorCore> MajorCores { get; set; }

        public DbSet<DegreeCore> DegreeCores { get; set; }

        public DbSet<PrerequisiteCourse> Prerequisites { get; set; }

        public DbSet<NeededPrereq> NeededPrereqs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            //some foreign key on delete no cascades
            modelbuilder.Entity<YearDegree>()
                .HasOptional(y => y.Majors)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<YearDegree>()
                .HasOptional(y => y.DegreeCores)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.ProgramStructure> ProgramStructures { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.ProgramMajor> ProgramMajors { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.ProgramElective> ProgramElectives { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.ProgramDirected> ProgramDirecteds { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.ProgramOptionalCoreCourse> ProgramOptionalCoreCourses { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.OptionalCoreCourse> OptionalCoreCourses { get; set; }

        public System.Data.Entity.DbSet<ProgramPlanner.Models.DegreeCoreSlot> DegreeCoreSlots { get; set; }
    }
}
