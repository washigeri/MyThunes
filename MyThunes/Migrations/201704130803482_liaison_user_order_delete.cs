namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liaison_user_order_delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "UserId");
            DropColumn("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "UserId", c => c.Int(nullable: false));
        }
    }
}
