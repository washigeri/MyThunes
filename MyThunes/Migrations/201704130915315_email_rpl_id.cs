namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email_rpl_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserEmail", c => c.String(nullable: false));
            DropColumn("dbo.Reviews", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "UserEmail");
        }
    }
}
