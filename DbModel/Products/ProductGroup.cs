using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
