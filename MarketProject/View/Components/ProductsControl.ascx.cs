using DbModel.ViewModel;
using MarketManagment.Managers.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject.View.Components
{
    public partial class ProductsControl : System.Web.UI.UserControl
    {
        ProductManager manager;
        public IEnumerable<ProductViewModel> products
        {
            get
            {
                return (IEnumerable<ProductViewModel>)Session["Products"];
            }
            set
            {
                Session["Products"] = value;
            }
        }
        public bool IsProductChanged;
        public int SelectedProductId
        {
            get
            {
                int Id;
                int.TryParse(DropDownProducts.SelectedItem.Value, out Id);
                return Id;
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                manager = new ProductManager();
                products = manager.ViewModelList();
                var objData = ProductsBinderList(); 
                DropDownProducts.DataSource = objData;
                DropDownProducts.DataBind();

                dropDownSearchCriteria.DataSource = InitSearchCriteria();
                dropDownSearchCriteria.DataBind();
            }
            IsProductChanged = false;
        }
        private ListItemCollection ProductsBinderList()
        {
            ListItemCollection ProductItems = new ListItemCollection();

            foreach (var item in products)
            {
                ProductItems.Add(new ListItem(item.Id.ToString(), item.Name));
            }
            return ProductItems;
        }

        private ListItemCollection InitSearchCriteria()
        {
            ListItemCollection types = new ListItemCollection();
            types.AddRange
                (
                    new ListItem[] {
                        new ListItem("Select","Select",false),
                        new ListItem("Name","Name"),
                        new ListItem("Code","Code"),
                        new ListItem("Producer","Producer"),
                        new ListItem("Barcode","Barcode"),
                        new ListItem("Group","Group"),

                    }
             );
            return types;
        }

        protected void DropDownProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsProductChanged = true;


        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void DropDownProducts_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dropDownSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}