namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created_Buy_enity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buys", "RetailPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buys", "RetailPrice");
        }
    }
}
