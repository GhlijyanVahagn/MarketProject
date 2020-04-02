using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.Model.BasketModel
{
    public class Basket
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public bool IsEmpty
        {
            get
            {
                return BasketItems.Count == 0;
            }
        }
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }
        public int BasketItemsCount
        {
            get
            {
                return BasketItems.Count;
            }
        }
        
     
    }
}
