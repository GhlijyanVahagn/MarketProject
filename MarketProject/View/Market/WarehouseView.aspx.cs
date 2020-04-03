using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbManager.Repository;
using DbModel.ViewModel;
using System.ComponentModel;

namespace MarketProject.View.Market
{
    public partial class WarehouseView : System.Web.UI.Page
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
            //var x= repository.GetRemindProductsFromWarehouseSearch(txtProductName.Text);
        }

        public void Delete(int Id)
        {

        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public List<WarehouseViewModel> GetWarehouses()
        {
            repository = new WareHouseRepository();
            var res=repository.ViewModelList().ToList();
            return res;
        }
    }
}