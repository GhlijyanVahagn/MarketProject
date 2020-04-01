using System;
using DbModel.Products;


using MarketManagment.Managers.Products;
using MarketManagment;

using MarketHelpers;
using DbModel.ViewModel;
using MarketManagment.User;

namespace MarketProject.View.AdminPanel
{
    [Authorized]
    public partial class UnitView : System.Web.UI.Page
    {
        UnitManager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
            manager=manager ?? new UnitManager();
            var unitsList = manager.ViewModelList();
            var binder = new UIControlBinder();
            binder.Bind<ProductUnitViewModel>(unitsList, gridUnit);



           
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var newUnit = new ProductUnitViewModel
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

          


            manager.Create(newUnit);
            manager.Save();
        }
        void RedirectToLoginPage()
        {

        }
        

        
    }
}