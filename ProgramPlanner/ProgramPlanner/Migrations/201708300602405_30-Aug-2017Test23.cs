namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test23 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramDirecteds");
            DropIndex("dbo.ProgramDirecteds", "Course_CourseID");
            DropIndex("dbo.ProgramStructures", "Course_CourseID");
            DropIndex("dbo.Courses", "Course_CourseID");
            DropIndex("dbo.Directeds", "Course_CourseID");
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgramDirecteds");
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID", "Completed" });
        }
    }
}
