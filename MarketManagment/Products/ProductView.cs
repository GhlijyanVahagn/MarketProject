using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Products
{

    /// <summary>
    /// Used for presentation 
    /// </summary>
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnicCode { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public string Producer { get; set; }
        public string UnitName { get; set; }
        public string GroupName { get; set; }

        public int ProducerId { get; set; }
        public int UnitId { get; set; }
        public int GroupId { get; set; }
    }
}
