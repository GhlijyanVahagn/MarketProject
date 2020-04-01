using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.RepositoryInterfaces
{
    public interface IRepository<TModel,TViewModel>: IViewModel<TViewModel>, ICrudOperation<TModel> where TModel : class
    {

    }
}
