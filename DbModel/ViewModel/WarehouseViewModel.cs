using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class WarehouseViewModel
    {
        public decimal Price { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal RetailSalePrice { get; set; }
        public ProductViewModel product { get; set; }


    }
}
