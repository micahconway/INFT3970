namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropPrimaryKey("dbo.Prerequisites");
            AlterColumn("dbo.Prerequisites", "CourseID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prerequisites", "CourseID");
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "CourseID", cascadeDelete: true);
            DropColumn("dbo.Prerequisites", "PrerequisiteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prerequisites", "PrerequisiteID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropPrimaryKey("dbo.Prerequisites");
            AlterColumn("dbo.Prerequisites", "CourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Prerequisites", "PrerequisiteID");
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
        }
    }
}
