using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
