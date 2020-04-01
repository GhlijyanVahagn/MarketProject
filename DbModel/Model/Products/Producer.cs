using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.Products
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
