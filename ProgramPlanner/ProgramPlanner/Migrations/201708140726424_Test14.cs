namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots");
            DropForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses");
            AddColumn("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID", c => c.Int());
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID");
            AddForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID", "dbo.DegreeCoreSlots", "DegreeCoreSlotID");
            AddForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots", "DegreeCoreSlotID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots");
            DropForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID", "dbo.DegreeCoreSlots");
            DropIndex("dbo.OptionalCoreCourses", new[] { "DegreeCoreSlot_DegreeCoreSlotID" });
            DropColumn("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID");
            AddForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots", "DegreeCoreSlotID", cascadeDelete: true);
        }
    }
}
