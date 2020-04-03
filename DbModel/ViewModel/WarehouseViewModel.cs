using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public decimal Remind { get; set; }
        public decimal RetailSalePrice { get; set; }
        public decimal Price { get; set; }
        public decimal WholeSalePrice { get; set; }
        public int ProductId { get; set; }

        public string Product{ get ;set;}
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Producer { get; set; }
        public string Unit { get; set; }
        public string Group { get; set; }
        public ProductViewModel ProductView { get; set; }

    }
}
