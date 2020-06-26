using System;
using DbModel.Products;


using MarketManagment.Managers.Products;
using MarketManagment;

using MarketHelpers;
using DbModel.ViewModel;
using MarketManagment.User;
using System.Collections.Generic;
using MarketManagment.Managers.Validator;
using System.Net.Http;

namespace MarketProject.View.AdminPanel
{
    [Authorized]
    public partial class UnitView : System.Web.UI.Page
    {
        UnitManager manager;
        IEnumerable<ProductUnitViewModel> unitsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
            manager=manager ?? new UnitManager();
            unitsList = manager.ViewModelList();
            var binder = new UIControlBinder();
            binder.Bind<ProductUnitViewModel>(unitsList, gridUnit);



           
        }

        protected async void BtnSave_Click(object sender, EventArgs e)
        {
            var newUnit = new ProductUnitViewModel
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

            HttpClient client = new HttpClient();
            var x=await client.GetAsync("https://localhost:44313/api/Login/4");
           

            var valid=manager.Validatation(new UnitValidator(unitsList, newUnit));
            if(valid!=string.Empty)
            {
                return;
            }
            manager.CreateAndSave(newUnit);

        }
        void RedirectToLoginPage()
        {

        }
        

        
    }
}