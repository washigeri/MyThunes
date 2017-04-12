namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Price", c => c.Int(nullable: false));
        }
    }
}
