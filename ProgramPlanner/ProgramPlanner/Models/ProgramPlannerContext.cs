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

        //-------------------------------------------------------------------------------------
        //----------------------------------DATABASE MODELS------------------------------------: 
        /// <summary>
        /// Constructs model schemas for database context. 
        /// </summary>
        /// <param name="modelbuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            Models(modelbuilder);
            Relationships(modelbuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void Models(DbModelBuilder modelbuilder)
        {
            ModelCourse(modelbuilder);
            ModelYearDegree(modelbuilder);
            ModelReplacement(modelbuilder);
            ModelSemester(modelbuilder);
            ModelTrimester(modelbuilder);
            ModelSemesterCourse(modelbuilder);
            ModelTrimesterCourse(modelbuilder);
            ModelReplacement(modelbuilder);
            ModelProgramElective(modelbuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelCourse(DbModelBuilder modelbuilder)
        {
            // Also referrenced in the class Course as data annotations (Required)
            // Remove these later. 
            modelbuilder.Entity<Course>()
                .Property(y => y.CourseCode).IsRequired();

            modelbuilder.Entity<Course>()
                .Property(y => y.CourseName).IsRequired();

            modelbuilder.Entity<Course>()
                .Property(y => y.UniversityID).IsRequired();

            modelbuilder.Entity<Course>()
                .Property(y => y.Units).IsRequired();

            modelbuilder.Entity<Course>().
                Property(y => y.CategoryID).IsRequired();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelProgramElective(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramElective>().HasKey(y => new {y.CourseID, y.ProgramStructureID});
        }

        /// <summary>
        /// Constructs the schema for entity YearDegree in the database context.
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelYearDegree(DbModelBuilder modelbuilder)
        {              
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
        /// Constructs the schema for entity Replacement in the database context;
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelReplacement(DbModelBuilder modelbuilder)
        {
            // Creating a new composite Primary key for entity Replacement;
            modelbuilder.Entity<Replacement>().HasKey(y => new {y.ReplacedCourseID, y.ReplacementCourseID, y.YearDegreeID});
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelSemester(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Semester>().Property(y => y.SemesterValue).IsRequired();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelTrimester(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Trimester>().Property(y => y.TrimesterValue).IsRequired();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelSemesterCourse(DbModelBuilder modelbuilder)
        {
            // Creating a new composite Primary key. 
            modelbuilder.Entity<SemesterCourse>().HasKey(y => new { y.SemesterCourseID, y.SemesterID, y.CourseID});
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelTrimesterCourse(DbModelBuilder modelbuilder)
        {
            // Creating a new composite Primary key. 
            modelbuilder.Entity<TrimesterCourse>().HasKey(y => new { y.TrimesterCourseID, y.TrimesterID, y.CourseID });
        }

        //-------------------------------------------------------------------------------------
        //---------------------------------ENTITY ASSOCIATIONS---------------------------------:

        /// <summary>
        /// Defines associations between entities for database context.
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void Relationships(DbModelBuilder modelbuilder)
        {
            RelationshipsForCourse(modelbuilder);
            RelationshipsForReplacement(modelbuilder);
        }

        /// <summary>
        /// Defines the relationships for the entity Course.  
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForCourse(DbModelBuilder modelbuilder)
        {
            // A Course has a required Category, and a Category is associated with many Courses. 
            // In the Course entity the Foreign key for the Category is CategoryID.
            // If the Course entity is deleted, the associated Category will not be.
            modelbuilder.Entity<Course>().HasRequired(y => y.Category)
                .WithMany()
                .HasForeignKey(y =>y.CategoryID)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<Course>()
               .HasMany(y => y.MandatoryPrerequisites)
               .WithMany()
               .Map(
                    Mandatory => {
                        Mandatory.MapLeftKey("CourseID");
                        Mandatory.MapRightKey("PrerequisiteID");
                        Mandatory.ToTable("MandatoryPrerquisites");
                    });


            modelbuilder.Entity<Course>()
               .HasMany(y => y.OptionalPrerequisites)
               .WithMany()
               .Map(
                    Mandatory => {
                        Mandatory.MapLeftKey("CourseID");
                        Mandatory.MapRightKey("PrerequisiteID");
                        Mandatory.ToTable("OptionalPrerequisites");
                    });
        }
        /// <summary>
        /// Defines all associations for entity Replacement. 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForReplacement(DbModelBuilder modelbuilder)
        {

            // Constraint: The attribute(ReplacedCourse) is not null 
            modelbuilder.Entity<Replacement>()
              .HasRequired(y => y.ReplacedCourse)
              .WithMany()
              .HasForeignKey(y => y.ReplacedCourseID)
               // if Replacement data is deleted, then the ReplacedCourse will not be deleted.
              .WillCascadeOnDelete(false);

            // Constraint: The attribute(ReplacementCourse) is not null
            modelbuilder.Entity<Replacement>()
                .HasRequired(y => y.ReplacementCourse)
                .WithMany()
                .HasForeignKey(y => y.ReplacementCourseID)
                 // if Replacement data is deleted, then the ReplacementCourse will not be deleted.
                .WillCascadeOnDelete(false);

            // Constraint: The attribute(YearDegree) is not null
            modelbuilder.Entity<Replacement>()
                .HasRequired(y => y.YearDegree)
                .WithMany()
                .HasForeignKey(y => y.YearDegreeID)
                 // if Replacement data is deleted, then the YearDegree will not be deleted.
                .WillCascadeOnDelete(false);
        }
    }
}
