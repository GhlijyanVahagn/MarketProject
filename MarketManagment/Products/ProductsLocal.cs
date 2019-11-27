using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagment.Products
{
    public static class ProductsLocal
    {
        /// <summary>
        /// Using this static property instead of SQL query
        /// </summary>
        public static IEnumerable<ProductView> LocalProducts { get; set; }




        public static async void RefreshLocalProductsList(bool ChacForCountChanged)
        {
            if(ChacForCountChanged)
            {
                if (ProductManager.GetProductsCountFromDataBase() != LocalProducts.Count())
                {
                    MarketManagment.Products.ProductsLocal.LocalProducts = await ProductManager.GetALLProductDetailInfo();

                }
            }
            else
                MarketManagment.Products.ProductsLocal.LocalProducts = await ProductManager.GetALLProductDetailInfo();
        }
       
    }
}
