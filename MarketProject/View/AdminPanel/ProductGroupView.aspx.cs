using System;
using DbModel;
using MarketManagment;
namespace MarketProject.View.AdminPanel
{
    public partial class ProductGroupView : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var _newProdGroup = new ProductGroup()
            {
                Name = txtName.Text.Trim(),
                Descrption = txtDescription.Text.Trim()

            };
            if (string.IsNullOrWhiteSpace(_newProdGroup.Name))
                return;

            ProductManager.CreateProductGroupAsync(_newProdGroup);
        }
    }
}