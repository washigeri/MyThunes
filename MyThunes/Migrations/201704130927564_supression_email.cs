namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supression_email : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "UserEmail", c => c.String(nullable: false));
        }
    }
}
