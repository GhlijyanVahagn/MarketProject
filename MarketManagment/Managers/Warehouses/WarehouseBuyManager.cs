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

                    var _prod = _db.Warehouse.Where(x => x.ProductId == buy.ProductId).FirstOrDefault();
                    if (_prod == null)
                    {
                        //need to add product 

                        _db.Warehouse.Add(new Warehouse() { ProductId = buy.ProductId, TotalRemind = buy.Count, RetailPrice = buy.RetailPrice });
                    }

                    else
                    {
                        //need to  update product

                        if (buy.RetailPrice != 0 && buy.RetailPrice != _prod.RetailPrice)
                            _prod.RetailPrice = buy.RetailPrice;
                        _prod.TotalRemind += buy.Count;
                        _db.Warehouse.Attach(_prod);
                        _db.Entry<Warehouse>(_prod).State = EntityState.Modified;
                    }

                }

                _db.SaveChanges();
            }





        }

       




        //public static  List<WareHouseViewer> ConvertFromWarehouseToWarehouseViewer(List<Warehouse> warehouses)
        //{

        //    var resultList = new List<WareHouseViewer>();
        //    //foreach(var item in warehouses)
        //    //{


        //    //   // var whItem = ProductManager.GetProductById(item.ProductId);
        //    //    resultList.Add(
        //    //        new WareHouseViewer()
        //    //        {
        //    //            RemindTotal = item.TotalRemind,
        //    //            RetailPrice = item.RetailPrice,
        //    //            ProductName = whItem.Name,
        //    //            UnicCode=whItem.UnicCode,
        //    //            BarCode= whItem.BarCode,

        //    //        });
        //    //}
        //    return resultList;
        //}
    }
}
