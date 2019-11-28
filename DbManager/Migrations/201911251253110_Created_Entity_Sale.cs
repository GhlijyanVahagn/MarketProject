namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created_Entity_Sale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Payed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.DateTime(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId)
                .Index(t => t.ProductId);


            Sql(@"
                    CREATE TRIGGER [dbo].[TG_Sale] ON [dbo].[Sales] AFTER INSERT,DELETE,UPDATE AS 
                    BEGIN
	                    SET NOCOUNT ON;

	                    declare @IsExsist int
	                    set @IsExsist=(SELECT count(*) from Warehouses where productId=(select ProductId from INSERTED))
	
	                    IF @IsExsist>0 
		                    BEGIN
			                    UPDATE Warehouses SET TotalRemind=TotalRemind-(select [count] from INSERTED where INSERTED.productId=Warehouses.productId)
		
			                    UPDATE Warehouses SET TotalRemind=TotalRemind+(select [count] from DELETED where DELETED.productId=Warehouses.productId)
		                    END
	                    END
                    GO
                ");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "TransactionId" });
            DropTable("dbo.Sales");

            Sql(@"DROP TRIGGER [dbo].[TG_Sale]");
        }
    }
}
