namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerValidations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Description", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "Description");
        }
    }
}
