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

namespace MarketManagment.Warehouses
{
    public static class WareHouseManagment
    {
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
        //public static  void AddToWarehouse(List<Buy> buys)
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {
        //        foreach (var buy in buys)
        //        {

        //            var _prod = _db.Warehouse.Where(x => x.ProductId == buy.ProductId).FirstOrDefault();
        //            if (_prod == null)
        //            {
        //                //need to add product 

        //                _db.Warehouse.Add(new Warehouse() { ProductId = buy.ProductId, TotalRemind = buy.Count, RetailPrice = buy.RetailPrice });
        //            }

        //            else
        //            {
        //                //need to  update product

        //                if (buy.RetailPrice != 0 && buy.RetailPrice != _prod.RetailPrice)
        //                    _prod.RetailPrice = buy.RetailPrice;
        //                _prod.TotalRemind += buy.Count;
        //                _db.Warehouse.Attach(_prod);
        //                _db.Entry<Warehouse>(_prod).State = EntityState.Modified;
        //            }

        //        }

        //        _db.SaveChanges();
        //    }





        //}

        //public static void SaleFromWarehouseWithTransaction(List<Sale> sales)
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {


        //        using (var transact = _db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                foreach (var sale in sales)
        //                {

        //                    var _whProd = _db.Warehouse.Where(x => x.ProductId == sale.ProductId).FirstOrDefault();
        //                    if (_whProd == null)
        //                    {
        //                        throw new InvalidOperationException();
        //                    }

        //                    else
        //                    {
        //                        //need to  update product


        //                        _whProd.TotalRemind -= sale.Count;
        //                        _db.Warehouse.Attach(_whProd);
        //                        _db.Entry<Warehouse>(_whProd).State = EntityState.Modified;
        //                    }

        //                }

        //                _db.SaveChanges();
        //                transact.Commit();
        //            }
        //            catch
        //            {
        //                transact.Rollback();
        //                throw new InvalidOperationException();
        //            }
        //        }
        //    }


        //}


        /// <summary>
        //Remove Row from Table with current productId
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        //public static bool RemoveFromWarehouse(int ProductId)
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {

        //        var _warehouseItem = _db.Warehouse.Where(x => x.ProductId == ProductId).FirstOrDefault();
        //        if (_warehouseItem != null)
        //        {
        //            _db.Warehouse.Remove(_warehouseItem);
        //        }

        //        return _db.SaveChanges() > 0;
        //    }

        //}
        /// <summary>
        /// Remove Produucts from warehouse with ids
        /// </summary>
        /// <param name="producIds"></param>
        /// <returns></returns>
        //public static bool RemoveItemsFromWarehouse(List<int> producIds)
        //{
        //    using (DataBaseManager _db = new DataBaseManager())
        //    {
        //        foreach (var id in producIds)
        //        {
        //            var _removeItem = _db.Warehouse.FirstOrDefault(x => x.ProductId == id);
        //            _db.Warehouse.Attach(_removeItem);
        //            _db.Entry<Warehouse>(_removeItem).State = EntityState.Deleted;
        //        }

        //        return _db.SaveChanges() > 0;
        //    }
        //}

        public static  List<WareHouseViewer> ConvertFromWarehouseToWarehouseViewer(List<Warehouse> warehouses)
        {

            var resultList = new List<WareHouseViewer>();
            foreach(var item in warehouses)
            {


                var whItem = ProductManager.GetProductById(item.ProductId);
                resultList.Add(
                    new WareHouseViewer()
                    {
                        RemindTotal = item.TotalRemind,
                        RetailPrice = item.RetailPrice,
                        ProductName = whItem.Name,
                        UnicCode=whItem.UnicCode,
                        BarCode= whItem.BarCode,

                    });
            }
            return resultList;
        }
    }
}
