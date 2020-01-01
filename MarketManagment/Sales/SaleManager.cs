using DbManager;
using DbModel;
using MarketManagment.Shared;
using MarketManagment.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Sales
{
    public static class SaleManager
    {
        private static DataBaseManager DataBase = DataBaseManager.GetDatabaseInstance();

        public static List<Sale> BasketItems { get; set; } = new List<Sale>();

        public static List<SaleView> ConvertFromSaleToSaleViewer(List<Sale> Sales)
        {

            List<SaleView> saleViewers = new List<SaleView>();
            foreach (var item in Sales)
            {
                var _saleViewer = new SaleView();
                _saleViewer.Id = item.Id;
                _saleViewer.Count = item.Count;
                _saleViewer.Price = item.Price;
                _saleViewer.ProductName = ProductManager.GetProductNameById(item.ProductId);
                _saleViewer.Total = item.Count * item.Price;
                _saleViewer.Discount = item.Discount;
                _saleViewer.Payed = item.Payed;
                saleViewers.Add(_saleViewer);
            }
            return saleViewers;
        }
        public static decimal TotalMoney
        {
            get
            {
                return BasketItems.Sum(x => x.Price * x.Count-(x.Price*x.Count)*x.Discount/100);

            }
        }
        public static decimal TotalCount
        {
            get
            {
                return BasketItems.Sum(x => x.Count);
            }
        }

        public static List<SaleView> ShowBasketViewItems()
        {
            return ConvertFromSaleToSaleViewer(SaleManager.BasketItems);

        }

        public static bool IsExistItemInBasket
        {
            get
            {
                return BasketItems.Count() > 0;
            }
        }

        public static void AddNewItemToBasket(Sale item)
        {

            BasketItems.Add(item);

        }

        public static void ClearBasketItems()
        {
            BasketItems.Clear();
        }

        public static bool ComplateSaleOrder(List<Sale> BasketItems, string LogedInUserName)
        {

            using (DataBase)
            {
                using (var transact = DataBase.Database.BeginTransaction())
                {
                    try
                    {

                        var transaction = new Transaction((int)ETransactionType.Sell, DateTime.Now, LogedInUserName);
                        DataBase.Transaction.Add(transaction);
                        DataBase.SaveChanges();
                        foreach (var item in BasketItems)
                        {

                            item.TransactionId = transaction.Id;
                        }

                        DataBase.Sale.AddRange(BasketItems);
                        DataBase.SaveChanges();
                        WareHouseManagment.SaleFromWarehouseWithTransaction(BasketItems);

                        transact.Commit();
                        return true;

                    }
                    catch(Exception e)
                    {
                        transact.Rollback();
                        return false;
                    }

                }
            }

        }
    }
}
