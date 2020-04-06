namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_dateAnduserFiledsFromSale : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sales", "DateTime");
            DropColumn("dbo.Sales", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "UserName", c => c.String());
            AddColumn("dbo.Sales", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
