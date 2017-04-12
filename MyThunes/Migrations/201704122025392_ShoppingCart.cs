namespace MyThunes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Albums", new[] { "Order_ID" });
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "ID");
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderId");


            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        AlbumId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ShoppingCartViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCartViewModels", t => t.ShoppingCartViewModel_Id)
                .Index(t => t.AlbumId)
                .Index(t => t.ShoppingCartViewModel_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Username", c => c.String());
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "Address", c => c.String());
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "State", c => c.String());
            AddColumn("dbo.Orders", "PostalCode", c => c.String());
            AddColumn("dbo.Orders", "Country", c => c.String());
            AddColumn("dbo.Orders", "Phone", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            //AddPrimaryKey("dbo.Orders", "OrderId");
            DropColumn("dbo.Albums", "Order_ID");
            //DropColumn("dbo.Orders", "ID");
            DropColumn("dbo.Orders", "Number");
            DropColumn("dbo.Orders", "BuyDate");
            DropColumn("dbo.Orders", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "BuyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Albums", "Order_ID", c => c.Int());
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_Id", "dbo.ShoppingCartViewModels");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Carts", "AlbumId", "dbo.Albums");
            DropIndex("dbo.OrderDetails", new[] { "AlbumId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_Id" });
            DropIndex("dbo.Carts", new[] { "AlbumId" });
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "Username");
            DropColumn("dbo.Orders", "OrderId");
            DropTable("dbo.ShoppingCartViewModels");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Carts");
            AddPrimaryKey("dbo.Orders", "ID");
            CreateIndex("dbo.Albums", "Order_ID");
            AddForeignKey("dbo.Albums", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
