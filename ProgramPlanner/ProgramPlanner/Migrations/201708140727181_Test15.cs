namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test15 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OptionalCoreCourses", new[] { "DegreeCoreSlot_DegreeCoreSlotID" });
            DropForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID", "dbo.DegreeCoreSlots");
            DropColumn("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID");

        }

        public override void Down()
        {
        }
    }
}
