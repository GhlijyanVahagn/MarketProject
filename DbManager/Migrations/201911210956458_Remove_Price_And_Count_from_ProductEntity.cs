namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Price_And_Count_from_ProductEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Count", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
