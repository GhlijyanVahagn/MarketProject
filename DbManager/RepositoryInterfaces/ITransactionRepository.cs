using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Model;
using DbModel.Enums;

namespace DbManager.RepositoryInterfaces
{
    interface ITransactionRepository
    {
        IEnumerable<TransactionVieweModel> GetTransactionsByType(ETransactionType type, DateTime startDate, DateTime endDate);
    }
}
