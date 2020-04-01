using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.Products
{
    public class Product:ProductBase
    {
        public int ProducerId { get; set; }
        public int UnitId { get; set; }
        public int GroupId { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ProductGroup ProductGroup { get;set;}
        public ICollection<Buy>Buy { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }

       
    }
}
