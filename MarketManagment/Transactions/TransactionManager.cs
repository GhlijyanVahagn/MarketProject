using DbManager.Repository;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Transactions
{
    public class TransactionManager
    {
        TransactionRepository repository;
             
        public TransactionManager()
        {
            repository = new TransactionRepository();
        }

        public IEnumerable<TransactionVieweModel> GetSaleTransactions(DateTime dateStart,DateTime dateEnd)
        {
            return repository.GetSaleTransactions(dateStart, dateEnd);
        }

        public IEnumerable<TransactionVieweModel> GetBuyTransactions(DateTime dateStart, DateTime dateEnd)
        {
            return repository.GetBuyTransactions(dateStart, dateEnd);
        }

        public IEnumerable<TransactionDetailView> GetTransactionDetailViews(int transactionId)
        {
            return repository.GetTransactionDetailViews(transactionId);
        }
    }
}
