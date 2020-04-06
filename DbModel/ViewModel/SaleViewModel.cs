using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductUnit { get; set; }
        public string ProductId { get; set; }

        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal Payed { get; set; }
        public decimal Discount { get; set; }


    }
}
