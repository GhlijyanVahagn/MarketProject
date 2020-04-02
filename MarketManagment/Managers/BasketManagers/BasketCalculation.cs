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
        
       
        public int BasketItemsCount
        {
            get
            {
                return Basket.BasketItems.Count;
            }
        }

        public decimal TotalRetailPrice
        {
            get
            {
                return Basket.BasketItems.Sum(x => x.RetailPrice * x.Count);

            }
        }
        public decimal TotalWholeSalePrice
        {
            get
            {
                return Basket.BasketItems.Sum(x => x.WholeSalePrice * x.Count);

            }
        }
        public decimal TotalPrice
        {
            get
            {
                return Basket.BasketItems.Sum(x => x.Price * x.Count);

            }

        }
        public decimal TotalCount
        {
            get
            {
                return Basket.BasketItems.Sum(x => x.Count);
            }
        }

    }
}
