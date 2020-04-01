using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbManager.Repository;
namespace MarketProject.View.Market
{
    public partial class Warehouse : System.Web.UI.Page
    {
        private WareHouseRepository repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                repository = new WareHouseRepository();
            LoadingProductAsync();

        }
        private async void LoadingProductAsync()
        {

            //if (!Page.IsPostBack && MarketManagment.Products.ProductsLocal.LocalProducts == null || MarketManagment.Products.ProductsLocal.LocalProducts.Count() == 0)
            //    MarketManagment.Products.ProductsLocal.LocalProducts = await ProductManager.GetALLProductDetailInfo();
        }

        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            var x= repository.GetRemindProductsFromWarehouseSearch(txtProductName.Text);
        }
    }
}