namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replacements", "hello", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replacements", "hello");
        }
    }
}
