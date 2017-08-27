namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Directeds", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.AlternativeAssumedKnowledge", "AlternativeAKID", "dbo.Courses");
            DropForeignKey("dbo.AlternativeAssumedKnowledge", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.AssumedKnowledge", "AssumedKnowledgeID", "dbo.Courses");
            DropForeignKey("dbo.AssumedKnowledge", "CourseID", "dbo.Courses");
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Courses", "CourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Courses", "CourseID");
            AddForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Directeds", "Course_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.AlternativeAssumedKnowledge", "AlternativeAKID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.AlternativeAssumedKnowledge", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.AssumedKnowledge", "AssumedKnowledgeID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.AssumedKnowledge", "CourseID", "dbo.Courses", "CourseID");
        }
    }
}
