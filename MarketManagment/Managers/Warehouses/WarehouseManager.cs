using DbManager;
using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Warehouses
{
    public class WarehouseManager
    {
        public  bool RemoveProducts(IEnumerable<int> producIds)
        {
            using (WarehouseDbContext _db = new WarehouseDbContext())
            {
                foreach (var id in producIds)
                {
                    var _removeItem = _db.Warehouse.FirstOrDefault(x => x.ProductId == id);
                    _db.Warehouse.Attach(_removeItem);
                    _db.Entry<Warehouse>(_removeItem).State = EntityState.Deleted;
                }

                return _db.SaveChanges() > 0;
            }
        }

        public  bool RemoveProduct(int ProductId)
        {
            using (WarehouseDbContext _db = new WarehouseDbContext())
            {

                var _warehouseItem = _db.Warehouse.Where(x => x.ProductId == ProductId).FirstOrDefault();
                if (_warehouseItem != null)
                {
                    _db.Warehouse.Remove(_warehouseItem);
                }

                return _db.SaveChanges() > 0;
            }

        }

        public static async Task<IEnumerable<Warehouse>> GetALLProductsFromWarehouse()
        {
            using (WarehouseDbContext _db = new WarehouseDbContext())
            {
                return await _db.Warehouse.ToListAsync();
            }
        }
    }
}
