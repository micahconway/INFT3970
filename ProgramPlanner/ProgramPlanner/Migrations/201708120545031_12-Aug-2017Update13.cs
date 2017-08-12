namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropPrimaryKey("dbo.Prerequisites");
            AddColumn("dbo.Prerequisites", "PrerequisiteID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prerequisites", "PrerequisiteID");
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            DropColumn("dbo.Prerequisites", "CourseID");
            DropForeignKey("dbo.Courses", "PrerequisiteFor_CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prerequisites", "CourseID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropPrimaryKey("dbo.Prerequisites");
            DropColumn("dbo.Prerequisites", "PrerequisiteID");
            AddPrimaryKey("dbo.Prerequisites", "CourseID");
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "CourseID", cascadeDelete: true);
        }
    }
}
