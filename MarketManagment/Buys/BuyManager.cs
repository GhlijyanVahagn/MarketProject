
using DbManager;

using DbModel;
using DbModel.Model.BasketModel;
using MarketManagment.Buys;
using MarketManagment.Managers.BasketManagers;
using MarketManagment.Managers.Warehouses;
using MarketManagment.Shared;
using MarketManagment.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment
{
    public  class BuyManager
    {


        BasketManagerBase basketBase;
        public BuyManager(BasketManagerBase basket)
        {
            this.basketBase = basket;
        }

        public BuyManager()
        {
            basketBase = new BasketManager();
        }
        public string   ComplateOrder()
        {
            string message="";
            using (TransactionDbContext _db = new TransactionDbContext())
            {
                using (var transact = _db.Database.BeginTransaction())
                {
                    try
                    {

                        var transaction = new Transaction((int)ETransactionType.Buy, DateTime.Now, "");
                        _db.Transaction.Add(transaction);
                        _db.SaveChanges();

                        BasketToBuyEntityConvertor convertor = new BasketToBuyEntityConvertor(basketBase.Basket, transaction);

                        var buyList = convertor.Convert().ToList();
                        using (BuyDbContext buyDbContext = new BuyDbContext())
                        {
                            buyDbContext.Buy.AddRange(buyList);
                            buyDbContext.SaveChanges();
                        }

                        WarehouseBuyManager warehouseBuy = new WarehouseBuyManager(buyList);
                        warehouseBuy.ComplateBuyAction();

                        transact.Commit();
                       

                    }
                    catch (Exception e)
                    {
                        transact.Rollback();
                        message = e.Message+" "+e.InnerException.Message;
                    }

                }
            }
            return message;
        }

        public IEnumerable<BasketItem> ShowBasketViewItems(int itemId)
        {
            if (itemId > 0)
                return basketBase.Basket.BasketItems.Where(x => x.Id == itemId);
            else
                return basketBase.Basket.BasketItems;
        }
        public void RemoveBasketItem(int ItemId)
        {
            basketBase.Basket.BasketItems.RemoveAt(ItemId);
        }

       
    }

        
}

