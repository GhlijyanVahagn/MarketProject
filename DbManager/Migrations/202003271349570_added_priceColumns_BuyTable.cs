namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_priceColumns_BuyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "GroupId", "dbo.ProductGroups");
            DropIndex("dbo.Products", new[] { "GroupId" });
            AddColumn("dbo.Buys", "WholeSalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "ProductGroup_Id", c => c.Int());
            AddColumn("dbo.Producers", "Description", c => c.String());
            AddColumn("dbo.ProductGroups", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "UnicCode", c => c.String());
            AlterColumn("dbo.Producers", "Name", c => c.String());
            AlterColumn("dbo.ProductGroups", "Name", c => c.String());
            AlterColumn("dbo.Transactions", "UserName", c => c.String());
            AlterColumn("dbo.Units", "Name", c => c.String());
            CreateIndex("dbo.Products", "ProductGroup_Id");
            AddForeignKey("dbo.Products", "ProductGroup_Id", "dbo.ProductGroups", "Id");
            DropColumn("dbo.ProductGroups", "Descrption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductGroups", "Descrption", c => c.String());
            DropForeignKey("dbo.Products", "ProductGroup_Id", "dbo.ProductGroups");
            DropIndex("dbo.Products", new[] { "ProductGroup_Id" });
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Transactions", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.ProductGroups", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "UnicCode", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.ProductGroups", "Description");
            DropColumn("dbo.Producers", "Description");
            DropColumn("dbo.Products", "ProductGroup_Id");
            DropColumn("dbo.Buys", "WholeSalePrice");
            CreateIndex("dbo.Products", "GroupId");
            AddForeignKey("dbo.Products", "GroupId", "dbo.ProductGroups", "Id", cascadeDelete: true);
        }
    }
}
