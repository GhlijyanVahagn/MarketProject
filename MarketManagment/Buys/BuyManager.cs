
using DbManager;
using DbModel;
using MarketManagment.Buys;
using MarketManagment.Shared;
using MarketManagment.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment
{
    public static class BuyManager
    {
        private static DataBaseManager  _db = new DataBaseManager();
        public static List<Buy> BasketItems { get; set; } = new List<Buy>();

        public static void AddNewItemToBasket(Buy item)
        {

            BasketItems.Add(item);

        }
        public static void RemoveItemFromBasket(BuyViewer item)
        {
            //BasketItems.Remove(item);
        }
        /// <summary>
        /// Used In DataSource
        /// </summary>
        /// <param name="id"></param>
        public static void RemoveItemFromBasketById(int id)
        {
            if (id < 0)
                return;
            var item = BasketItems.Where(x => x.Id == id).FirstOrDefault();
            BasketItems.Remove(item);
        }
        public static void UpdateBasketItemInfo(int Id, decimal count,decimal price,decimal Payed,decimal Total,string ProductName,decimal RetailPrice)
        {

            foreach(var _editItem in BasketItems.Where(x => x.Id == Id))
            {
                _editItem.Price = price;
                _editItem.Count = count;
                _editItem.Payed = Payed;
                _editItem.RetailPrice = RetailPrice;

            }


        }

        //Count, Price, Payed, Id, ProductName, Total
        public static void ClearBasket()
        {
            BasketItems.Clear();

        }

        public static List<BuyViewer> ConvertFromBuyToBuyViewer(List<Buy> buys)
        {
            
            List<BuyViewer> buyViewers = new List<BuyViewer>();
            foreach (var item in buys)
            {
                var _buyerView = new BuyViewer();
                _buyerView.Id = item.Id;
                _buyerView.Count = item.Count;
                _buyerView.Price = item.Price;
                _buyerView.ProductName = ProductManager.GetProductNameById(item.ProductId);
                _buyerView.Total = item.Count * item.Price;
                _buyerView.RetailPrice = item.RetailPrice;
                _buyerView.Payed = _buyerView.Total;
                buyViewers.Add(_buyerView);
            }
            return buyViewers;
        }

        public static decimal TotalMoney
        {
            get
            {
                return BasketItems.Sum(x => x.Price * x.Count);

            }
        }
        public static decimal TotalCount
        {
            get
            {
                return BasketItems.Sum(x => x.Count);
            }
        }
        public static decimal TotalRetailPrice
        {
            get
            {
                return BasketItems.Sum(x => x.RetailPrice * x.Count );
            }
        }
        public static List<BuyViewer> ShowBasketViewItems()
        {
                return  ConvertFromBuyToBuyViewer(BuyManager.BasketItems);
            
        }

        public static bool IsExistItemInBasket
        {
            get
            {
                return BasketItems.Count() > 0;
            }
        }

        public static bool ComplateOrder(List<Buy> BasketItems,string LogedInUserName)
        {
          
                using (var context = new DataBaseManager())
                {
                    using (var transact = context.Database.BeginTransaction())
                    {
                        try
                        {

                            var transaction = new Transaction((int)ETransactionType.Buy, DateTime.Now, LogedInUserName);
                            _db.Transaction.Add(transaction);
                            _db.SaveChanges();
                            foreach(var item in BasketItems)
                            {
                                item.TransactionId = transaction.Id;
                            }

                            _db.Buy.AddRange(BasketItems);
                            _db.SaveChanges();
                                WareHouseManagment.AddToWarehouse(BasketItems);

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

