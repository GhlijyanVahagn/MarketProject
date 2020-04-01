using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Products;
namespace DbModel
{
    public class Buy
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }

        public decimal Payed { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }

    }
}
