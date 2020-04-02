namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_columns_UserNameAndDateTime_from_Buy_Table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buys", "DateTime");
            DropColumn("dbo.Buys", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buys", "UserName", c => c.String());
            AddColumn("dbo.Buys", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
