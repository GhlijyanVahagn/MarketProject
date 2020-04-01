using DbModel.Products;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.RepositoryInterfaces
{

    interface IProductUnitRepository: ICrudOperation<Unit>,IViewModel<ProductUnitViewModel>
    {
        void Save();
    }
}
