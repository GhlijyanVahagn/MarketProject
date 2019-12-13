

using DbManager;
using DbModel;
using MarketManagment.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment
{
    public static class ProductManager
    {
        private static DataBaseManager _db = new DataBaseManager();

        

        public static async void CreateProductGroupAsync(ProductGroup productGroup)
        {
             _db.ProductGroup.Add(productGroup);
            await _db.SaveChangesAsync();
        }
        public static async void CreateUnitAsync(Unit unit)
        {
            _db.Unit.Add(unit);
            await _db.SaveChangesAsync();
        }
        public static async void CreateProducerAsync(Producer producer)
        {
            _db.Producers.Add(producer);
            await _db.SaveChangesAsync();
        }
        public static async void CreateProduct(Product product)
        {
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
         

        }
        public static async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == Id); 
        }
        public static async void RemoveProductByIdAsync(int Id)
        {
            var _product = await GetProductByIdAsync(Id);
            if (_product == null)
                return;

            _db.Product.Remove(_product);
            await _db.SaveChangesAsync();


        }
        public static async Task<Producer> GetProducerByIdAsync(int Id)
        {
            return await _db.Producers.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public static async Task<bool> RemoveProducerById(int Id)
        {
            var producer = await GetProducerByIdAsync(Id);
            if (producer == null)
                return false;
            _db.Producers.Remove(producer);
            return  _db.SaveChanges()>0;
        }
        /// <summary>
        /// Need to refresh Products list after delete add or edit product
        /// </summary>
      
      

        #region SQL Query
        public static async Task<List<ProductView>> GetALLProductDetailInfo()
        {

            try
            {
                return await (from product in _db.Product

                                  join producer in _db.Producers on product.ProducerId equals producer.Id
                                  join unit in _db.Unit on product.UnitId equals unit.Id
                                  join pgroup in _db.ProductGroup on product.GroupId equals pgroup.Id

                                  // where product.Id == productId
                                  select new ProductView
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      UnicCode = product.UnicCode,
                                      BarCode = product.BarCode,
                                      Description = product.Description,
                                      //Price = product.Price,
                                      //Count = product.Count,
                                      Producer = producer.Name,
                                      UnitName = unit.Name,
                                      GroupName = pgroup.Name,

                                      ProducerId= producer.Id,
                                      UnitId=unit.Id,
                                      GroupId= pgroup.Id
                                  }).ToListAsync();

      
            }
            catch(Exception error)
            {
                return  null;

            }

        }
        public static async Task<IEnumerable<ProductView>> GetAllRemindProductsDetailInfo()
        {

            try
            {
                var producList = (from product in _db.Product

                                  join producer in _db.Producers on product.ProducerId equals producer.Id
                                  join unit in _db.Unit on product.UnitId equals unit.Id
                                  join pgroup in _db.ProductGroup on product.GroupId equals pgroup.Id
                                  join wh in _db.Warehouse on product.Id equals wh.ProductId
                                  where wh.TotalRemind > 0
                                  select new ProductView
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      UnicCode = product.UnicCode,
                                      BarCode = product.BarCode,
                                      Description = product.Description,
                                      //Price = product.Price,
                                      //Count = product.Count,
                                      Producer = producer.Name,
                                      UnitName = unit.Name,
                                      GroupName = pgroup.Name,

                                      ProducerId = producer.Id,
                                      UnitId = unit.Id,
                                      GroupId = pgroup.Id
                                  }).ToListAsync();

                return await producList;
            }
            catch
            {
                return null;

            }

        }
        public static ProductView GetProductInfoByIdFromDb(int ProductId)
        {
            try
            {
                var producList = (from product in _db.Product

                                  join producer in _db.Producers on product.ProducerId equals producer.Id
                                  join unit in _db.Unit on product.UnitId equals unit.Id
                                  join pgroup in _db.ProductGroup on product.GroupId equals pgroup.Id

                                  where product.Id == ProductId
                                  select new ProductView
                                  {
                                      Id = product.Id,
                                      Name = product.Name,
                                      UnicCode = product.UnicCode,
                                      BarCode = product.BarCode,
                                      Description = product.Description,
                                      //Price = product.Price,
                                      //Count = product.Count,
                                      Producer = producer.Name,
                                      UnitName = unit.Name,
                                      GroupName = pgroup.Name


                                  }).FirstOrDefault();

                return  producList;
            }
            catch
            {
                return null;
            }
            
        }

        public static async Task<IEnumerable<ProductView>> GetProductInfoByNameFromDbAsync(string ProductName)
        {
            try
            {
                var result=(from product in _db.Product
                 join producer in _db.Producers on product.ProducerId equals producer.Id
                 join unit in _db.Unit on product.UnitId equals unit.Id
                 join productgroup in _db.ProductGroup on product.GroupId equals productgroup.Id
                 where product.Name.Trim().ToLower().Equals(ProductName.Trim().ToLower())
                 select new ProductView
                 {
                     Id = product.Id,
                     Name = product.Name,
                     UnicCode = product.UnicCode,
                     BarCode = product.BarCode,
                     Description = product.Description,
                     //Price = product.Price,
                     //Count = product.Count,
                     Producer = producer.Name,
                     UnitName = unit.Name,
                     GroupName = productgroup.Name
                 }).ToListAsync();

                return await result;


            }
            catch
            {
                return null;
            }
        }

        public static async Task<IEnumerable<ProductView>> getProductInfoByUnicCodeFromDbAsync(string UnicalCode)
        {
            try
            {
                var result = (from product in _db.Product
                              join producer in _db.Producers on product.ProducerId equals producer.Id
                              join unit in _db.Unit on product.UnitId equals unit.Id
                              join productgroup in _db.ProductGroup on product.GroupId equals productgroup.Id
                              where product.UnicCode.Trim().ToLower().Equals(UnicalCode.Trim().ToLower())
                              select new ProductView
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  UnicCode = product.UnicCode,
                                  BarCode = product.BarCode,
                                  Description = product.Description,
                                  //Price = product.Price,
                                  //Count = product.Count,
                                  Producer = producer.Name,
                                  UnitName = unit.Name,
                                  GroupName = productgroup.Name
                              }).ToListAsync();

                return await result;


            }
            catch
            {
                return null;
            }
        }

        public static async Task<IEnumerable<ProductView>> getProductInfoByBarcodeFromDbAsync(string BarCode)
        {
            try
            {
                var result = (from product in _db.Product
                              join producer in _db.Producers on product.ProducerId equals producer.Id
                              join unit in _db.Unit on product.UnitId equals unit.Id
                              join productgroup in _db.ProductGroup on product.GroupId equals productgroup.Id
                              where product.BarCode.Trim().ToLower().Equals(BarCode.Trim().ToLower())
                              select new ProductView
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  UnicCode = product.UnicCode,
                                  BarCode = product.BarCode,
                                  Description = product.Description,
                                  //Price = product.Price,
                                  //Count = product.Count,
                                  Producer = producer.Name,
                                  UnitName = unit.Name,
                                  GroupName = productgroup.Name
                              }).ToListAsync();

                return await result;


            }
            catch
            {
                return null;
            }
        }

        public static async Task<IEnumerable<ProductView>> getProductInfoByProducerNameFromDbAsync(string ProducerName)
        {
            try
            {
                var result = (from product in _db.Product
                              join producer in _db.Producers on product.ProducerId equals producer.Id
                              join unit in _db.Unit on product.UnitId equals unit.Id
                              join productgroup in _db.ProductGroup on product.GroupId equals productgroup.Id
                              where producer.Name.Trim().ToLower().Equals(ProducerName.Trim().ToLower())
                              select new ProductView
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  UnicCode = product.UnicCode,
                                  BarCode = product.BarCode,
                                  Description = product.Description,
                                  //Price = product.Price,
                                  //Count = product.Count,
                                  Producer = producer.Name,
                                  UnitName = unit.Name,
                                  GroupName = productgroup.Name
                              }).ToListAsync();

                return await result;


            }
            catch
            {
                return null;
            }
        }

        public static async Task<IEnumerable<ProductView>> getProductInfoByProductGroupNameFromDbAsync(string groupName)
        {
            try
            {
                var result = (from product in _db.Product
                              join producer in _db.Producers on product.ProducerId equals producer.Id
                              join unit in _db.Unit on product.UnitId equals unit.Id
                              join productgroup in _db.ProductGroup on product.GroupId equals productgroup.Id
                              where productgroup.Name.Trim().ToLower().Equals(groupName.Trim().ToLower())
                              select new ProductView
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  UnicCode = product.UnicCode,
                                  BarCode = product.BarCode,
                                  Description = product.Description,
                                  //Price = product.Price,
                                  //Count = product.Count,
                                  Producer = producer.Name,
                                  UnitName = unit.Name,
                                  GroupName = productgroup.Name
                              }).ToListAsync();

                return await result;


            }
            catch
            {
                return null;
            }
        }

        public static int GetProductsCountFromDataBase()
        {
            return _db.Product.Count();
        }
        #endregion


        #region Local List Query

        public static ProductView GetProductById(int id)
        {
            return ProductsLocal.LocalProducts.Where(x => x.Id == id).FirstOrDefault();
        }
        public static IEnumerable<ProductView> GetProductByUnicCode(string unicCode)
        {
            return ProductsLocal.LocalProducts.Where(x => x.UnicCode.Trim().ToLower().Equals(unicCode.Trim().ToLower()));
        }
        public static IEnumerable<ProductView> GetProductByBarCode(string BarCode)
        {
            return ProductsLocal.LocalProducts.Where(x => x.BarCode.Trim().ToLower().Equals(BarCode.Trim().ToLower()));
        }
        public static IEnumerable<ProductView> GetProductByName(string Name)
        {
            return ProductsLocal.LocalProducts.Where(x => x.Name.Trim().ToLower().Equals(Name.Trim().ToLower()));
        }
        public static IEnumerable<ProductView> GetProductByProducerId(int ProducerId)
        {
            return ProductsLocal.LocalProducts.Where(x => x.ProducerId== ProducerId);
        }
        public static IEnumerable<ProductView> GetProductByProducerName(string ProducerName)
        {
            return ProductsLocal.LocalProducts.Where(x => x.Producer.Trim().ToLower().Equals(ProducerName.Trim().ToLower()));
        }

        public static string GetProductNameById(int id)
        {
            if (ProductsLocal.LocalProducts == null || ProductsLocal.LocalProducts.Count() == 0)
               ProductsLocal.RefreshLocalProductsList(false);
            return ProductsLocal.LocalProducts.FirstOrDefault(x => x.Id == id)?.Name;
        }
        public static void AddToLocalList(ProductView product)
        {
            ProductsLocal.LocalProducts.Add(product);
        }
        public static decimal GetLastSalePriceByProductId(int productId, decimal price=0)
        {
            var lastBuy = _db.Buy.Where(x => x.ProductId == productId && x.Price >= price).OrderByDescending(x => x.TransactionId).FirstOrDefault();
            if (lastBuy != null)
                return lastBuy.RetailPrice;
            return 0;

        }
        #endregion
    }
}
