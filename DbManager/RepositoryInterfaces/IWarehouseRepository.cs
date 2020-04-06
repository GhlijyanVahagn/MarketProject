using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.RepositoryInterfaces
{
    interface IWarehouseRepository: ICrudOperation<Warehouse>, IViewModel<WarehouseViewModel>
    {
        //Task<decimal> GetProductPriceByIdAsync(int productId);
        //Task<List<Warehouse>> GetALLProductsFromWarehouseAsync();
        //List<Warehouse> GetRemindProductsFromWarehouseSearch(string filter);
        //void AddToWarehouse(List<Buy> buys);
        //bool RemoveFromWarehouse(int ProductId);
        //bool RemoveItemsFromWarehouse(List<int> producIds);
        //void SaleFromWarehouseWithTransaction(List<Sale> sales);
    }
}
