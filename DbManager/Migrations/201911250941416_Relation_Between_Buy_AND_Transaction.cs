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

            Sql(@"
                    CREATE TRIGGER [dbo].[TG_Buys] ON [dbo].[Buys] AFTER INSERT,DELETE,UPDATE AS 
                    BEGIN
	                SET NOCOUNT ON;
	                    declare @IsExsist int
	                    set @IsExsist=(SELECT count(*) from Warehouses where productId=(select ProductId from INSERTED))
	                    IF @IsExsist>0 
		                    BEGIN
			                    UPDATE Warehouses SET TotalRemind=TotalRemind+(select [count] from INSERTED where INSERTED.productId=Warehouses.productId)
		
			                    UPDATE Warehouses SET TotalRemind=TotalRemind-(select [count] from DELETED where DELETED.productId=Warehouses.productId)
		                    END
	                    ELSE
		                    BEGIN
			                    INSERT INTO  Warehouses(TotalRemind,RetailPrice,ProductId) select [count],RetailPrice,ProductId from INSERTED 
		                    END
	                    END
                        GO
                    ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buys", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Buys", new[] { "TransactionId" });
            DropColumn("dbo.Buys", "TransactionId");
            Sql(@"DROP TRIGGER[dbo].[TG_Buys]");
        }
    }
}
