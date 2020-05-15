namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_EntityGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "GenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "GenderId");
            AddForeignKey("dbo.Customers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "Gender");

            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Gender", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "GenderId" });
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
