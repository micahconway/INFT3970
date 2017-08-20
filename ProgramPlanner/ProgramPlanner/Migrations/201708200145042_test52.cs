namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test52 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AlternativeAssumedKnowledge", "Prerequisite", c => c.Int(nullable: false));
            AlterColumn("dbo.AssumedKnowledge", "Prerequisite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
