
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Model.BasketModel;

namespace MarketManagment.Managers.BasketManagers
{
    public abstract class BasketManagerBase
    {
        public abstract Basket Basket { get; set; }
        public abstract void Add(BasketItem item);
        public abstract void Remove(BasketItem item);
        public abstract void Edit(BasketItem item);
     
        
        public void ClearBasket()
        {
            Basket.BasketItems.Clear();
        }

  
    }
}
