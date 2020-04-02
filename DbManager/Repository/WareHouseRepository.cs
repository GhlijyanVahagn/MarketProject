using DbManager;
using DbManager.RepositoryInterfaces;
using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
    public class WareHouseRepository : IWarehouseRepository
    {
        private WarehouseDbContext _context;
        public WareHouseRepository()
        {
            _context = new WarehouseDbContext();
        }

     

        public void AddToWarehouse(List<Buy> buys)
        {
            using (_context)
            {
                foreach (var buy in buys)
                {

                    var _prod = _context.Warehouse.Where(x => x.ProductId == buy.ProductId).FirstOrDefault();
                    if (_prod == null)
                    {
                        //need to add product 

                        _context.Warehouse.Add(new Warehouse() { ProductId = buy.ProductId, TotalRemind = buy.Count, RetailPrice = buy.RetailPrice });
                    }

                    else
                    {
                        //need to  update product

                        if (buy.RetailPrice != 0 && buy.RetailPrice != _prod.RetailPrice)
                            _prod.RetailPrice = buy.RetailPrice;
                        _prod.TotalRemind += buy.Count;
                        _context.Warehouse.Attach(_prod);
                        _context.Entry<Warehouse>(_prod).State = EntityState.Modified;
                    }

                }

                _context.SaveChanges();
            }

        }

        public void Create(Warehouse entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Warehouse>> GetALLProductsFromWarehouseAsync()
        {
            return await _context.Warehouse.ToListAsync();
        }


        public async Task<decimal> GetProductPriceByIdAsync(int productId)
        {
            var obj= await _context.Warehouse.FindAsync(productId);
            return obj.RetailPrice;
        }

        public List<Warehouse> GetRemindProductsFromWarehouseSearch(string filter)
        {

            //using (_context)
            //{
            //    return (from wh in _context.Warehouse
            //            join product in _context.Product on wh.ProductId equals product.Id
            //            where (
            //            (filter == null || filter == "") ||
            //            product.Name.Trim().ToLower().Contains(filter.Trim().ToLower()))

            //            && wh.TotalRemind > 0
            //            select new WareHouseViewer
            //            {
            //                BarCode = product.BarCode,
            //                ProductName = product.Name,
            //                RemindTotal = wh.TotalRemind,
            //                RetailPrice = wh.RetailPrice
            //            }).ToList();

            //}

            return null;
        }

        public Warehouse Read(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromWarehouse(int ProductId)
        {
    

            using (_context)
            {

                var _warehouseItem = _context.Warehouse.Where(x => x.ProductId == ProductId).FirstOrDefault();
                if (_warehouseItem != null)
                {
                    _context.Warehouse.Remove(_warehouseItem);
                }

                return _context.SaveChanges() > 0;
            }


        }

        public bool RemoveItemsFromWarehouse(List<int> producIds)
        {
            using (_context)
            {
                foreach (var id in producIds)
                {
                    var _removeItem = _context.Warehouse.FirstOrDefault(x => x.ProductId == id);
                    _context.Warehouse.Attach(_removeItem);
                    _context.Entry<Warehouse>(_removeItem).State = EntityState.Deleted;
                }

                return _context.SaveChanges() > 0;
            }
        }

        public void SaleFromWarehouseWithTransaction(List<Sale> sales)
        {
            using (_context)
            {


                using (var transact = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var sale in sales)
                        {

                            var _whProd = _context.Warehouse.Where(x => x.ProductId == sale.ProductId).FirstOrDefault();
                            if (_whProd == null)
                            {
                                throw new InvalidOperationException();
                            }

                            else
                            {
                                //need to  update product


                                _whProd.TotalRemind -= sale.Count;
                                _context.Warehouse.Attach(_whProd);
                                _context.Entry<Warehouse>(_whProd).State = EntityState.Modified;
                            }

                        }

                        _context.SaveChanges();
                        transact.Commit();
                    }
                    catch
                    {
                        transact.Rollback();
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Warehouse entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseViewModel> ViewModelList()
        {
            throw new NotImplementedException();
        }
    }
}
