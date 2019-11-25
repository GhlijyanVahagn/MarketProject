using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnicCode { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        //public decimal Price { get; set; }
        //public decimal Count { get; set; }
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
