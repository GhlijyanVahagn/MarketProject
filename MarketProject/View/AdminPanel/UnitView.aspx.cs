using System;
using DbModel;
using System.Web.UI.WebControls;

using MarketManagment;
using MarketHelpers;

namespace MarketProject.View.AdminPanel
{
    [Authorized]
    public partial class UnitView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newUnit = new DbModel.Unit()
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };
            ProductManager.CreateUnitAsync(newUnit);
        }
        void RedirectToLoginPage()
        {

        }
        

        
    }
}