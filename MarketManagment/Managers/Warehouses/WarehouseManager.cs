using DbManager;
using DbManager.Repository;
using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Warehouses
{
    public class WarehouseManager : BaseManager<Warehouse, WarehouseViewModel>
    {
        WareHouseRepository repo;
        public WarehouseManager():base(new WareHouseRepository())
        {
           
        }
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

        

        public override void Create(WarehouseViewModel entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public override WarehouseViewModel Read(int Id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<WarehouseViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update(WarehouseViewModel entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<WarehouseViewModel> ViewModelList()
        {
            throw new NotImplementedException();
        }
    }
}
