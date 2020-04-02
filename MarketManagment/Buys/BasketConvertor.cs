using DbModel;
using DbModel.Model.BasketModel;
using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Buys
{
    class BasketToBuyEntityConvertor
    {
        Basket Basek;
        Transaction Transact;
        public BasketToBuyEntityConvertor(Basket basket,Transaction transaction)
        {
            this.Basek = basket;
            this.Transact = transaction;
        }
        public IEnumerable<Buy> Convert()
        {
            foreach(var bItem in Basek.BasketItems)
            {
                Buy buy = new Buy();
                buy.Price = bItem.Price;
                buy.RetailPrice = bItem.RetailPrice;
                buy.WholeSalePrice = bItem.WholeSalePrice;
                buy.ProductId = bItem.ProductId;
                buy.Count = bItem.Count;
                buy.TransactionId =Transact.Id;
                yield return buy;
            }
        }
    }
}
