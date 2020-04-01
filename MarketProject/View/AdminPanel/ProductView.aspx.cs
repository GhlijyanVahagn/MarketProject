using MarketHelpers;
using MarketManagment.Products;
using MarketManagment.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketManagment.Managers.Products;
using DbModel.Products;
using DbModel.ViewModel;
using MarketManagment.Managers.Validator;

namespace MarketProject.View.AdminPanel
{
    public partial class ProductView : System.Web.UI.Page
    {

        ProductManager manager;
        IEnumerable<ProductViewModel> source;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                BindDataToView();

            }
            manager = manager ?? new ProductManager();
            FillGrid();

        }
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

        private  void FillGrid()
        {
            source=manager.ViewModelList();
            gridProduct.DataSource = source;
            gridProduct.DataBind();

            //var sqlDataSourceProduct = new SqlDataSource(Helpers.ConnectionString, "SELECT Id,Name,UnicCode,BarCode,ProducerId,UnitId,GroupId,Description FROM Products");
            //gridProduct.DataSource = sqlDataSourceProduct;
            //gridProduct.DataBind();
        }


      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int unitId, groupId, producerId;

            int.TryParse(comboUnit.SelectedValue,out unitId);
            int.TryParse(comboGroup.SelectedValue,out groupId);
            int.TryParse(comboCountry.SelectedValue,out producerId);

            var product = new ProductViewModel()
            {
                Name = txtName.Text,
                Description = txtDescription.Text.Trim(),
                GroupId = groupId,
                UnitId = unitId,
                ProducerId = producerId,
                BarCode = txtBarCode.Text.Trim(),
                UnicCode = txtUnicalCode.Text,
            };
            int validation=manager.Validatation(new ProductValidator(source, product));
            if(validation!=-1)
            {
                CustomerError.Text = $"<br>     Error occured during Validation, {((EProductCreationValidationTypes)validation).ToString()}</br>";
                return;
                
            }
            manager.CreateAndSave(product);
            FillGrid();
        }

        protected void gridProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id;
            int.TryParse(e.Values["Id"].ToString(),out id);
            manager.Delete(id);
            FillGrid();
        }

        protected void gridProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}