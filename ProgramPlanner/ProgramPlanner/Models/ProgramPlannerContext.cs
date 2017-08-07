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

        public DbSet<User> Users { get; set; }

        public DbSet<ProgramStructure> ProgramStructures { get; set; }

        public DbSet<ProgramMajor> ProgramMajors { get; set; }

        public DbSet<ProgramElective> ProgramElectives { get; set; }

        public DbSet<ProgramDirected> ProgramDirecteds { get; set; }

        public DbSet<ProgramOptionalCoreCourse> ProgramOptionalCoreCourses { get; set; }

        public DbSet<OptionalCoreCourse> OptionalCoreCourses { get; set; }

        public DbSet<DegreeCoreSlot> DegreeCoreSlots { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Trimester> Trimesters { get; set; }

        public DbSet<SemesterCourse> SemesterCourses { get; set; }

        public DbSet<TrimesterCourse> TrimesterCourses { get; set; }

        public DbSet<Replacement> Replacements { get; set; }

        public DbSet<PrerequisiteCourse> PrerequisiteCourses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            ModelCourse(modelbuilder);
            ModelYearDegree(modelbuilder);
            ModelReplacement(modelbuilder);
            ModelPrerequisitie(modelbuilder);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Course>()
                .HasOptional(y => y.PrerequisiteCourses)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelYearDegree(DbModelBuilder modelbuilder) {
                             
            //some foreign key on delete no cascades
            modelbuilder.Entity<YearDegree>()
                .HasRequired(y => y.Majors)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<YearDegree>()
                .HasRequired(y => y.DegreeCores)
                .WithMany()
                .WillCascadeOnDelete(false);

            // Ignore the Class attribute YearDegreeName.
            modelbuilder.Entity<YearDegree>()
                .Ignore(y => y.YearDegreeName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelReplacement(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Replacement>()
              .HasOptional(y => y.ReplacedCourse)
              .WithMany()
              .HasForeignKey(y => y.ReplacedCourseID)
              .WillCascadeOnDelete(false);

            modelbuilder.Entity<Replacement>()
                .HasOptional(y => y.ReplacementCourse)
                .WithMany()
                .HasForeignKey(y => y.ReplacementCourseID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelPrerequisitie(DbModelBuilder modelbuilder) {
            modelbuilder.Entity<PrerequisiteCourse>()
                .HasRequired(y => y.RequiredCourse)
                .WithMany()
                .HasForeignKey(y => y.RequiredCourseID)
                .WillCascadeOnDelete(false);


            modelbuilder.Entity<PrerequisiteCourse>()
                .HasRequired(y => y.Prerequisite)
                .WithMany()
                .HasForeignKey(y => y.PrerequisiteID)
                .WillCascadeOnDelete(false);
        }
    }
}
