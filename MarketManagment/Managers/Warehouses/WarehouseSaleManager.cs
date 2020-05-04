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
    public class WarehouseSaleManager
    {
        IEnumerable<Sale> sales;
        public WarehouseSaleManager(IEnumerable<Sale> salesList)
        {
            this.sales = salesList;
        }
        public  void ComplateSale()
        {
            using (WarehouseDbContext _db = new WarehouseDbContext())
            {
                //using (var transact = _db.Database.BeginTransaction())
                //{
                    try
                    {
                        foreach (var sale in sales)
                        {

                            var _whProd = _db.Warehouse.Where(x => x.ProductId == sale.ProductId).FirstOrDefault();
                            if (_whProd == null)
                            {
                                throw new InvalidOperationException();
                            }

                            else
                            {
                            //need to  update product

                            if (_whProd.TotalRemind < sale.Count)
                                throw new Exception("Count not available");
                                _whProd.TotalRemind -= sale.Count;
                                _db.Warehouse.Attach(_whProd);
                                _db.Entry<Warehouse>(_whProd).State = EntityState.Modified;
                            }

                        }

                        _db.SaveChanges();
                        //transact.Commit();
                    }
                    catch
                    {
                        //transact.Rollback();
                        throw ;
                    }
                }
            }
        }
}
