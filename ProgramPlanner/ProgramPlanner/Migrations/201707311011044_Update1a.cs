namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "MajorID", "dbo.Majors");
            DropIndex("dbo.Courses", new[] { "MajorID" });
            DropColumn("dbo.Courses", "MajorID");
            DropColumn("dbo.Courses", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Courses", "MajorID", c => c.Int());
            CreateIndex("dbo.Courses", "MajorID");
            AddForeignKey("dbo.Courses", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: true);
        }
    }
}
