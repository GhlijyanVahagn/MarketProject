
using DbModel;
using DbModel.ViewModel;
using MarketHelpers;
using MarketManagment.Managers.Customers;
using MarketManagment.Managers.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.AdminPanel
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        CustomerManager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                 manager = manager ?? new CustomerManager();

           
      
        }

        enum EGender
        {
            Mail=1,
            Femail=2
        }

        protected void createNewCustomer_Click(object sender, EventArgs e)
        {

            var newCustomer = new CustomerViewModel()
            {
                Name = CustomerNametxt.Text,
                Surname = Surnametxt.Text,
                Phone = phonetxt.Text,
                Email = emailtxt.Text,
                Address = Addresstxt.Text,
                GenderId = dropDownGender.SelectedValue.ConvertEnumValueToInt32<EGender>(),
                Birthday = birthdaytxt.Text.ConvertToDateTime(),
                Description = DescriptionText.Text
            };
            string errorMessage=manager.Validatation(new CustomerValidator(null, newCustomer));

            if (errorMessage != string.Empty)
            {
                errorLabel.Text = errorMessage;
                return;

            }

            manager.CreateAndSave(newCustomer);
            
        }
    }
}