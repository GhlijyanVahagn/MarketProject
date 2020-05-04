using System;
using System.Collections.Generic;

namespace DbModel
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public  List<Buy> Buys { get; set; }
        public  List<Sale> Sales { get; set; }

        public Transaction()
        {

        }
        public Transaction(int TransactionType,DateTime date, string UserName)
        {
            this.Type = TransactionType;
            this.Date= date;
            this.UserName = UserName;

        }

    }
}
