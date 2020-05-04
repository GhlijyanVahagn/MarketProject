using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class TransactionDetailView
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime ActionDate { get; set; }
        public string Username { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public decimal Payed { get; set; }
        public decimal Discount { get; set; }
        public string Product { get; set; }
    }
}
