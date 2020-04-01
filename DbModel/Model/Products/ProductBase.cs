using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.Products
{
    public abstract class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnicCode { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }

    }
}
