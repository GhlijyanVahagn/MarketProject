namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created_TransactionDetail_SP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.SP_TransactionDetails",
                p => new
                    {
                        TransactionId = p.Int(),
                  
                },

                body:

	                @"SELECT Transactions.Id, [Type],[Date] AS ActionDate,UserName,Sales.[count],Sales.Price,Sales.Payed,Sales.Discount,Products.[Name] AS Product
	            FROM Transactions
	            INNER JOIN Sales ON Sales.transactionId=Transactions.Id
	            INNER JOIN Products ON Products.Id=Sales.ProductId
	            WHERE Transactions.Id=@transactionId OR @transactionId=-1

	            UNION ALL

	            SELECT Transactions.Id,[Type],[Date] AS ActionDate,UserName,Buys.[count],Buys.Price,Buys.Payed,0,Products.[Name] AS Product
	            FROM Transactions
	            INNER JOIN Buys ON Buys.transactionId=Transactions.Id
	            INNER JOIN Products ON Products.Id=Buys.ProductId
	            WHERE Transactions.Id=@transactionId OR @transactionId=-1 
	            ORDER BY Transactions.Id"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SP_TransactionDetails");
        }
    }
}
