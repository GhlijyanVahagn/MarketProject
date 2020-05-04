using DbManager;
using DbModel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Managers.Warehouses
{
    public  class WarehouseBuyManager
    {
        IEnumerable<Buy> buys;
        public WarehouseBuyManager(IEnumerable<Buy> buyList)
        {
            this.buys = buyList;
        }
        //private static DataBaseManager _db=DataBaseManager.GetDatabaseInstance();



        //public static async Task<decimal> GetProductPriceById(int productId)
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {
        //        var currentProduct =await _db.Warehouse.FirstOrDefaultAsync(x => x.ProductId == productId);

        //        return currentProduct != null ? currentProduct.RetailPrice : 0;
        //    }
        //}
        //public static async Task<List<Warehouse>> GetALLProductsFromWarehouse()
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {
        //        return await _db.Warehouse.ToListAsync();
        //    }
        //}
        /// <summary>
        /// Binded to datasource                                                       
        /// </summary>
        /// <returns></returns>
        //public static  List<WareHouseViewer> GetRemindProductsFromWarehouseSearch(string filter)
        //{

        //    using (DataBaseManager _db = new DataBaseManager())
        //    {
        //        return (from wh in _db.Warehouse
        //                join product in _db.Product on wh.ProductId equals product.Id
        //                where (
        //                (filter == null || filter == "") ||
        //                product.Name.Trim().ToLower().Contains(filter.Trim().ToLower()))

        //                && wh.TotalRemind > 0
        //                select new WareHouseViewer
        //                {
        //                    BarCode = product.BarCode,
        //                    ProductName = product.Name,
        //                    RemindTotal = wh.TotalRemind,
        //                    RetailPrice = wh.RetailPrice
        //                }).ToList();

        //    }

        //}
        /// <summary>
        /// Update warehouse price and Count
        /// Or insert a row 
        /// </summary>
        /// <param name="buys"></param>
        public  void ComplateBuyAction()
        {
            using (WarehouseDbContext _db = new WarehouseDbContext())
            {
                foreach (var buy in buys)
                {

                    var warehouse = _db.Warehouse.Where(x => x.ProductId == buy.ProductId).FirstOrDefault();
                    if (warehouse == null)
                    {
                        //need to add product 

                        _db.Warehouse.Add(new Warehouse()
                        {
                            ProductId = buy.ProductId,
                            TotalRemind = buy.Count,
                            RetailPrice = buy.RetailPrice,
                            Price = buy.Price,
                            WholeSalePrice = buy.WholeSalePrice,

                        });
                    }

                    else
                    {
                        //need to  update product

                        if (buy.RetailPrice != 0 && buy.RetailPrice != warehouse.RetailPrice)
                        {
                            warehouse.RetailPrice = buy.RetailPrice;
                            warehouse.Price = buy.Price;
                            warehouse.WholeSalePrice = buy.WholeSalePrice;

                        }
                        warehouse.TotalRemind += buy.Count;
                        _db.Warehouse.Attach(warehouse);
                        _db.Entry<Warehouse>(warehouse).State = EntityState.Modified;
                    }

                }

                _db.SaveChanges();
            }
        }
    }
}
