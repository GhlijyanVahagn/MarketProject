namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation_Between_Buy_AND_Transaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buys", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Buys", "TransactionId");
            AddForeignKey("dbo.Buys", "TransactionId", "dbo.Transactions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buys", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Buys", new[] { "TransactionId" });
            DropColumn("dbo.Buys", "TransactionId");
        }
    }
}
