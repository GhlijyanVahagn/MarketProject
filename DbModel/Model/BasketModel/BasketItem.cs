using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Products;
using DbModel.ViewModel;

namespace DbModel.Model.BasketModel
{
    public class BasketItem
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public decimal Count { get; set; }
        public int ProductId { get; set; }
        public decimal Discount { get; set; }

        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }

        public decimal Total{ get { return Count * RetailPrice; } }
        public string ProductName { get { return Product.Name; } }
            
    }
}
