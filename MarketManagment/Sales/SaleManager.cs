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
        private static DataBaseManager _db = new DataBaseManager();
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

        public static bool ComplateSaleOrder(List<Sale> BasketItems, string LogedInUserName)
        {

            using (var context = new DataBaseManager())
            {
                using (var transact = context.Database.BeginTransaction())
                {
                    try
                    {

                        var transaction = new Transaction((int)ETransactionType.Sell, DateTime.Now, LogedInUserName);
                        _db.Transaction.Add(transaction);
                        _db.SaveChanges();
                        foreach (var item in BasketItems)
                        {
                            item.TransactionId = transaction.Id;
                        }

                        _db.Sale.AddRange(BasketItems);
                        _db.SaveChanges();
                        WareHouseManagment.SaleFromWarehouse(BasketItems);

                        transact.Commit();
                        return true;

                    }
                    catch
                    {
                        transact.Rollback();
                        return false;
                    }

                }
            }

        }
    }
}
