using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.Market
{
    public partial class Warehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadingProductAsync();

        }
        private async void LoadingProductAsync()
        {

            if (!Page.IsPostBack && MarketManagment.Products.ProductsLocal.LocalProducts == null || MarketManagment.Products.ProductsLocal.LocalProducts.Count() == 0)
                MarketManagment.Products.ProductsLocal.LocalProducts = await ProductManager.GetALLProductDetailInfo();
        }

        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            var x=MarketManagment.Warehouses.WareHouseManagment.GetRemindProductsFromWarehouseSearch(txtProductName.Text);
        }
    }
}