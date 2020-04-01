using DbModel;
using DbModel.Model.BasketModel;
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
        int TransactId;
        public BasketToBuyEntityConvertor(Basket basket,int transactionId)
        {
            this.Basek = basket;
            this.TransactId = transactionId;
        }
        public IEnumerable<Buy> Convert()
        {
            foreach(var bItem in Basek.BasketItems)
            {
                Buy buy = new Buy();
                buy.DateTime = DateTime.Now;
                buy.Price = bItem.Price;
                buy.RetailPrice = bItem.RetailPrice;
                buy.WholeSalePrice = bItem.WholeSalePrice;
                buy.ProductId = bItem.ProductId;
                buy.Count = bItem.Count;
                buy.TransactionId = TransactId;
                yield return buy;
            }
        }
    }
}
