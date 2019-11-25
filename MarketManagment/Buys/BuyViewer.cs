using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Buys
{
    public class BuyViewer
    {
        public int Id { get; set; } = 0;
        public string ProductName { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal Payed { get; set; }
        public decimal Total { get;  set; }
        public decimal RetailPrice { get; set; }
     

    }
}
