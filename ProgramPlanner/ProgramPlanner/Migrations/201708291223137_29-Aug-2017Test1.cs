namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29Aug2017Test1 : DbMigration
    {
        public override void Up()
        {
           // DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            //AlterColumn("dbo.Replacements", "ReplacementCourse_CourseID", c => c.Int());
            //CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            AlterColumn("dbo.Replacements", "ReplacementCourse_CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
        }
    }
}
