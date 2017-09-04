namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Directeds", new[] { "Course_CourseID" });
           // RenameColumn(table: "dbo.Directeds", name: "Course_CourseID", newName: "CourseID");
            AlterColumn("dbo.Directeds", "CourseID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Directeds", "CourseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Directeds", new[] { "CourseID" });
            AlterColumn("dbo.Directeds", "CourseID", c => c.Int());
            RenameColumn(table: "dbo.Directeds", name: "CourseID", newName: "Course_CourseID");
            CreateIndex("dbo.Directeds", "Course_CourseID");
        }
    }
}
