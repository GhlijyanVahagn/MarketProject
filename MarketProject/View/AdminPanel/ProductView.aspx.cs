using MarketHelpers;
using MarketManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.AdminPanel
{
    public partial class ProductView : System.Web.UI.Page
    {
     

        private void BindDataToView()
        {


            this.DataBind();
            var sqlDataSourceUnit = new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name FROM Units");
     
            comboUnit.DataSource = sqlDataSourceUnit;
            comboUnit.DataValueField = "Id";
            comboUnit.DataTextField = "Name";
            comboUnit.DataBind();


            var sqlDataSourceProductGroups = new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name FROM ProductGroups");
            comboGroup.DataSource = sqlDataSourceProductGroups;
            comboGroup.DataValueField = "Id";
            comboGroup.DataTextField = "Name";
            comboGroup.DataBind();

            var sqlDataSourceProducers = new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name FROM Producers");
            comboCountry.DataSource = sqlDataSourceProducers;
            comboCountry.DataValueField = "Id";
            comboCountry.DataTextField = "Name";
            comboCountry.DataBind();


        }

        private async void FillGrid()
        {
            var productList = MarketManagment.Products.ProductsLocal.LocalProducts;

            if (productList == null || productList.Count() == 0)
            {
                productList = await ProductManager.GetALLProductDetailInfo();
                MarketManagment.Products.ProductsLocal.LocalProducts = productList;

            }

            //var sqlDataSourceProduct= new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name,UnicCode,BarCode,ProducerId,UnitId,GroupId,Description FROM Products");
            //gridProduct.DataSource = sqlDataSourceProduct;
            //gridProduct.DataBind();


            // var sqlDataSourceProduct = new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name,UnicCode,BarCode,ProducerId,UnitId,GroupId,Description FROM Products");
            gridProduct.DataSource = productList;
            gridProduct.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                BindDataToView();
                FillGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int unitId, groupId, producerId;

            int.TryParse(comboUnit.SelectedValue,out unitId);
            int.TryParse(comboGroup.SelectedValue,out groupId);
            int.TryParse(comboCountry.SelectedValue,out producerId);

            ProductManager.CreateProduct(
                    new DbModel.Product()
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text.Trim(),
                        GroupId = groupId,
                        UnitId = unitId,
                        ProducerId = producerId,
                        BarCode = txtBarCode.Text.Trim(),
                        UnicCode = txtUnicalCode.Text,
                    }
                );


            FillGrid();
      



        }

        protected void gridProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _productId;
            int.TryParse(gridProduct.Rows[e.RowIndex].Cells[2].Text, out _productId);
            ProductManager.RemoveProductByIdAsync(_productId);
            FillGrid();
        }
        private async void RefreshProductLocalList()
        {
            MarketManagment.Products.ProductsLocal.LocalProducts = await ProductManager.GetALLProductDetailInfo();
        }
       
        
    }
}