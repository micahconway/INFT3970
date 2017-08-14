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
            ModelDegreeCore(modelbuilder);
            ModelMajors(modelbuilder);
            ModelMajorCore(modelbuilder);
            ModelSemester(modelbuilder);
            ModelTrimester(modelbuilder);
            ModelSemesterCourse(modelbuilder);
            ModelTrimesterCourse(modelbuilder);
            ModelReplacement(modelbuilder);
            ModelDirected(modelbuilder);
            ModelProgramMajor(modelbuilder);
            ModelProgramElective(modelbuilder);
            ModelProgramDirected(modelbuilder);
            ModelUniversity(modelbuilder);
            ModelUser(modelbuilder);
            ModelProgramStructure(modelbuilder);
            ModelProgramOptionalCoreCourse(modelbuilder);
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
            // Ignore the Class attribute YearDegreeName.
            modelbuilder.Entity<YearDegree>().Ignore(y => y.YearDegreeName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelMajors(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Major>().Property(y => y.MajorName).IsRequired();
            modelbuilder.Entity<Major>().Property(y => y.YearDegreeID).IsRequired();
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
        private void ModelDegree(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Degree>().Property(y => y.DegreeName).IsRequired();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelDegreeCore(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DegreeCore>().HasKey(y => new { y.CourseID, y.YearDegreeID});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelMajorCore(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<MajorCore>().HasKey(y => new {y.CourseID, y.MajorID });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelSemester(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Semester>().HasKey(y => new { y.SemesterID});
            modelbuilder.Entity<Semester>().Property(y => y.SemesterValue).IsRequired();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelTrimester(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Trimester>().HasKey(y => new { y.TrimesterID });
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelDirected(DbModelBuilder modelbuilder)
        {
           // modelbuilder.Entity<Directed>().HasKey(y => new {y.DirectedID });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelProgramMajor(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramMajor>().HasKey(y => new { y.ProgramStructureID, y.MajorID });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelProgramDirected(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramDirected>().HasKey(y => new { y.ProgramStructureID, y.DirectedID });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelUniversity(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<University>().Property(y => y.UniName).IsRequired();
            modelbuilder.Entity<University>().Property(y => y.UniName).HasMaxLength(250);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelUser(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().Property(y => y.Email).IsRequired();
            modelbuilder.Entity<User>().Property(y => y.Password).IsRequired();
            modelbuilder.Entity<User>().HasKey(y => y.Email);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelProgramStructure(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramStructure>().Property(y => y.DateCreated).IsRequired();
            modelbuilder.Entity<ProgramStructure>().Property(y => y.DateModified).IsRequired();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void ModelProgramOptionalCoreCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramOptionalCoreCourse>().HasKey(y => new { y.ProgramStructureID, y.OptionalCoreID});
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
            RelationshipsForYearDegree(modelbuilder);
            RelationshipsForDegree(modelbuilder);
            RelationshipsForDegreeCore(modelbuilder);
            RelationshipsForReplacement(modelbuilder);
            RelationshipsForMajorCore(modelbuilder);
            RelationshipsForProgramMajor(modelbuilder);
            RelationshipsForProgramElective(modelbuilder);
            RelationshipsForProgramDirected(modelbuilder);
            RelationshipsForProgramStructures(modelbuilder);
            RelationshipsForUser(modelbuilder);
            RelationshipsForMajors(modelbuilder);
            RelationshipsForOptionalCoreCourses(modelbuilder);
            RelationshipsForSemesterCourse(modelbuilder);
            RelationshipsForTrimesterCourse(modelbuilder);
            RelationshipsForProgramOptionalCoreCourse(modelbuilder);
        }

        /// <summary>
        /// Defines the relationships for the entity Course.  
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Course>()
                .HasRequired(y => y.Category)
                .WithMany()
                .HasForeignKey(y =>y.CategoryID)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<Course>()
                 .HasRequired(y => y.University)
                 .WithMany()
                 .HasForeignKey(y => y.UniversityID)
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
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForYearDegree(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<YearDegree>().HasRequired(y => y.Degree).WithMany().HasForeignKey(y => y.DegreeID).WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForDegree(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Degree>().HasRequired(y => y.University).WithMany().HasForeignKey(y => y.UniversityID).WillCascadeOnDelete(false);
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
              .WillCascadeOnDelete(false);

            // Constraint: The attribute(ReplacementCourse) is not null
            modelbuilder.Entity<Replacement>()
                .HasRequired(y => y.ReplacementCourse)
                .WithMany()
                .HasForeignKey(y => y.ReplacementCourseID)
                .WillCascadeOnDelete(false);

            // Constraint: The attribute(YearDegree) is not null
            modelbuilder.Entity<Replacement>()
                .HasRequired(y => y.YearDegree)
                .WithMany()
                .HasForeignKey(y => y.YearDegreeID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForMajorCore(DbModelBuilder modelbuilder)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForDegreeCore(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DegreeCore>().HasRequired(y => y.Course).WithMany().HasForeignKey(y => y.CourseID).WillCascadeOnDelete(false);
            modelbuilder.Entity<DegreeCore>().HasRequired(y => y.YearDegree).WithMany().HasForeignKey(y => y.YearDegreeID).WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForProgramDirected(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramDirected>().HasRequired(y => y.ProgramStructure).WithMany().WillCascadeOnDelete(false);
            modelbuilder.Entity<ProgramDirected>().HasRequired(y => y.Directed).WithMany().HasForeignKey(y => y.DirectedID).WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForProgramElective(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramElective>().HasRequired(y => y.ProgramStructure).WithMany().WillCascadeOnDelete(false);
            modelbuilder.Entity<ProgramElective>().HasRequired(y => y.Course).WithMany().HasForeignKey(y => y.CourseID).WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForProgramMajor(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramMajor>().HasRequired(y => y.ProgramStructure).WithMany().WillCascadeOnDelete(false);
            modelbuilder.Entity<ProgramMajor>().HasRequired(y => y.Major).WithMany().HasForeignKey(y => y.MajorID).WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForProgramStructures(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramStructure>().HasRequired(y => y.User).WithMany().HasForeignKey(y => y.Email);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForUser(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().HasMany(y => y.ProgramStructures);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForMajors(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Major>()
                .HasRequired(y => y.YearDegree)
                .WithMany()
                .HasForeignKey(y => y.YearDegreeID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForSemesterCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SemesterCourse>()
                .HasRequired(y => y.Semester)
                .WithMany()
                .HasForeignKey(y => y.SemesterID)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<SemesterCourse>()
                .HasRequired(y => y.Course)
                .WithMany()
                .HasForeignKey(y => y.CourseID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForTrimesterCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<TrimesterCourse>()
                .HasRequired(y => y.Trimester)
                .WithMany()
                .HasForeignKey(y => y.TrimesterID)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<TrimesterCourse>()
                .HasRequired(y => y.Course)
                .WithMany()
                .HasForeignKey(y => y.CourseID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForOptionalCoreCourses(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<OptionalCoreCourse>()
                .HasRequired(y => y.DegreeCoreSlot)
                .WithMany()
                .HasForeignKey(y => y.DegreeCoreSlotID)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<OptionalCoreCourse>()
                .HasRequired(y => y.Course)
                .WithMany()
                .HasForeignKey(y => y.CourseID)
                .WillCascadeOnDelete(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelbuilder"></param>
        private void RelationshipsForProgramOptionalCoreCourse(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProgramOptionalCoreCourse>().HasRequired(y => y.ProgramStructure).WithMany().HasForeignKey(y => y.ProgramStructureID).WillCascadeOnDelete(false);
            modelbuilder.Entity<ProgramOptionalCoreCourse>().HasRequired(y => y.OptionalCoreCourse).WithMany().HasForeignKey(y => y.OptionalCoreID).WillCascadeOnDelete(false);
        }
    }
}
