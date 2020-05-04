using DbManager.RepositoryInterfaces;
using DbModel;
using DbModel.Enums;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
   public class TransactionRepository : ITransactionRepository
    {
        private TransactionDbContext context;
        public TransactionRepository()
        {
            context = new TransactionDbContext();
        }
        public IEnumerable<TransactionVieweModel> GetTransactionsByType(ETransactionType type,DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions=null;

            if (startDate==null && endDate!=null && endDate != default(DateTime))
                 transactions= context.Transaction.Where(x => x.Type == (int)type && x.Date<=endDate.Date ).ToList();

            if (startDate != null &&  startDate != default(DateTime) && endDate==null)
                transactions = context.Transaction.Where(x => x.Type == (int)type && x.Date >= startDate.Date).ToList();

            if (startDate != null && startDate != default(DateTime) && endDate!=null &&  endDate != default(DateTime))
                transactions = context.Transaction.Where(x => x.Type == (int)type && x.Date >= startDate.Date && x.Date<=endDate.Date).ToList();

            //if ((startDate == null || startDate == default(DateTime)) && (endDate == null || endDate == default(DateTime)))
            //    transactions = context.Transaction.Where(x => x.Type == (int)type).ToList();

            List<TransactionVieweModel> transactionsViewResult = null; 

            if (transactions!=null)
            {
                transactionsViewResult= new List<TransactionVieweModel>();
                foreach (var transaction in transactions)
                {
                    var viewModel= MarketMapper.Mapper.Map<Transaction, TransactionVieweModel>(transaction);
                    transactionsViewResult.Add(viewModel);
                }
            }
           

            return transactionsViewResult;
        }

        public IEnumerable<TransactionVieweModel> GetSaleTransactions(DateTime startDate, DateTime endDate)
        {
            return GetTransactionsByType(ETransactionType.Sell,  startDate,  endDate);
        }

        public IEnumerable<TransactionVieweModel> GetBuyTransactions(DateTime startDate, DateTime endDate)
        {
            return GetTransactionsByType(ETransactionType.Buy, startDate, endDate);
        }

        public IEnumerable<TransactionDetailView> GetTransactionDetailViews(int transactionId)
        {
            SqlParameter param1 = new SqlParameter("@TransactionId", transactionId);
            return  context.Database.SqlQuery<TransactionDetailView>("SP_TransactionDetails @TransactionId", param1).ToList();
        }

   
    }
}
