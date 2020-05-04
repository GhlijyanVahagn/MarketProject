using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ViewModel
{
    public class TransactionVieweModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
