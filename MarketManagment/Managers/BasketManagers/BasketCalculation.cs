using DbModel.Products;
using DbModel.Model.BasketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.BasketManagers
{
    public class BasketCalculation
    {
        private Basket Basket;
        public BasketCalculation(Basket basket)
        {
            this.Basket = basket;
        }
        
        public decimal GetTotal()
        {
            return Basket.BasketItems.Sum(x => x.RetailPrice * x.Count);
        }
       
    }
}
