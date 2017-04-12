namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modif_validations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Albums", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Reviews", "Comment", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Comment", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            AlterColumn("dbo.Albums", "Name", c => c.String());
            DropColumn("dbo.Reviews", "UserID");
        }
    }
}
