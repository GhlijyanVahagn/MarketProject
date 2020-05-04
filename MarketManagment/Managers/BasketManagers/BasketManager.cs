using DbModel.Model.BasketModel;
using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.BasketManagers
{
    public class BasketManager : BasketManagerBase
    {
        public override Basket Basket { get; set; }

        public BasketManager(Basket basket)
        {
            this.Basket = basket;
        }
        public BasketManager()
        {
            Basket = new Basket();
            Basket.BasketItems = new List<BasketItem>();
        }
        public override void Add(BasketItem item)
        {
            Basket.BasketItems.Add(item);
        }

        public override void Edit(BasketItem item)
        {
           
            throw new NotImplementedException();
        }

        public override void Remove(BasketItem item)
        {
            Basket.BasketItems.Remove(item);
        }
        public  void Remove(int Id)
        {
            Basket.BasketItems.RemoveAt(Id);
        }

        public  BasketItem GetItem(int Id)
        {
           return Basket.BasketItems.FirstOrDefault(x => x.BasketItemId == Id);
        }

        public  List<BasketItem> GetItems()
        {
            return Basket.BasketItems.ToList();
        }
    }
}
