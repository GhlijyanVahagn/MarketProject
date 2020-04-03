using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Products;
namespace DbModel
{
    public class Warehouse
    {
        public int Id { get; set; }
        public decimal TotalRemind { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal Price { get; set; }
        public decimal WholeSalePrice { get; set; }
        public int ProductId { get; set; }
        //public Product product { get; set; }
        public virtual Product Products { get; set; }
 
 

    }
}
