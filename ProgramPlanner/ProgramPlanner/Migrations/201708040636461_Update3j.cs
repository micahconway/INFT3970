namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3j : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptionalCoreCourses",
                c => new
                    {
                        OptionalCoreCourseID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OptionalCoreCourseID);
            
            AddColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID", c => c.Int());
            CreateIndex("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
            AddForeignKey("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID", "dbo.OptionalCoreCourses", "OptionalCoreCourseID");
            DropColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID", "dbo.OptionalCoreCourses");
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "OptionalCoreCourse_OptionalCoreCourseID" });
            DropColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
            DropTable("dbo.OptionalCoreCourses");
        }
    }
}
