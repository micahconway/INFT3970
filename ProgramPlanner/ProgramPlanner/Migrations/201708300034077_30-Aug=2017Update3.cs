namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Update3 : DbMigration
    {
        public override void Up()
        {
            //AddForeignKey("dbo.Courses", "ReplacementID", "dbo.Replacements", "ReplacementID", cascadeDelete: false);
            AddForeignKey("dbo.Replacements", "ReplacementID", "dbo.Courses", "CourseID", cascadeDelete: false);
            CreateIndex("dbo.Courses", "ReplacementID");
        }

        public override void Down()
        {
        }
    }
}
