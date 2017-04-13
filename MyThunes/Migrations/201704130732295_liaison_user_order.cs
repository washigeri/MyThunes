namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liaison_user_order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.OrderDetails", "UserId");
        }
    }
}
