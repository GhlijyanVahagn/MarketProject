using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Transactions
{
    public class TransactionViewer
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
