namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update3 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Directeds", "DirectedSlotID", "dbo.DirectedSlots", "DirectedSlotID");
        }

        public override void Down()
        {
        }
    }
}
