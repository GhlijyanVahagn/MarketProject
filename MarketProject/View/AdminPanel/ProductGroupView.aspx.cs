using System;
using DbManager.ProductGroupRepository;

using MarketManagment.Managers.Products;
using MarketManagment;
using DbModel.ViewModel;
using MarketManagment.User;

namespace MarketProject.View.AdminPanel
{
    public partial class ProductGroupView : System.Web.UI.Page
    {

        ProductGroupManager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
            manager = new ProductGroupManager();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var newGroup = new ProductGroupViewModel()
            {
                
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim()

            };
            if (string.IsNullOrWhiteSpace(newGroup.Name))
                return;
            manager.Create(newGroup);
            manager.Save();

        }
    }
}