namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_columns_PriceAndWholeSalePrice_in_Warehouse_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Warehouses", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Warehouses", "WholeSalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Warehouses", "WholeSalePrice");
            DropColumn("dbo.Warehouses", "Price");
        }
    }
}
