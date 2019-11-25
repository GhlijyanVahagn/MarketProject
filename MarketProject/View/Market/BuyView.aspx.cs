using DbModel;
using MarketHelpers;
using MarketManagment;
using MarketManagment.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MarketProject.View.Market
{
    public partial class BuyView : System.Web.UI.Page
    {

        private DataBinder dataBinder = new DataBinder();
        

        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

            if(!IsPostBack)
            {
                txtCount.AutoPostBack = true;
                txtPrice.AutoPostBack = true;
                fillProductsDropDown();
            }
            SetBasketComplateVisible();

         
           
        }

    
        private async void fillProductsDropDown()
        {
            var prodList = MarketManagment.Products.ProductsLocal.LocalProducts;
            if(prodList==null || prodList.Count()==0)
            {
                prodList = await ProductManager.GetALLProductDetailInfo();
                MarketManagment.Products.ProductsLocal.LocalProducts= prodList;

            }
            InsertIntoDropDown(prodList);

        }

        private void CalculatePrice()
        {
            decimal price, count;
            decimal.TryParse(txtPrice.Text.Trim(), out price);
            decimal.TryParse(txtCount.Text.Trim(), out count);


            if (price > 0 && count > 0)
                lbltotalMoney.Text = $"{price * count} {UsersManager.Currency}";
        }

      


        protected  void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            IEnumerable<ProductView> result=null;
            if (rbnByName.Checked)
                result = ProductManager.GetProductByName(txtSearchString.Text);
            else if(rbnByUnicalCode.Checked)
                result = ProductManager.GetProductByUnicCode(txtSearchString.Text);
            else if (rbnByProducer.Checked)
                result = ProductManager.GetProductByProducerName(txtSearchString.Text);
            else if(rbnBarCode.Checked)
                result = ProductManager.GetProductByBarCode(txtSearchString.Text);

            InsertIntoDropDown(result);



        }
        private void ClearDropDownList()
        {
        }
        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void InsertIntoDropDown(IEnumerable<ProductView> prodList)
        {
       
            if (prodList == null || prodList.Count() == 0)
                return;
            dropDownProducts.Items.Clear();
            dropDownProducts.Items.Insert(0, "Select product");


            int index = 1;
            foreach (var item in prodList)
                dropDownProducts.Items.Insert(index++, Helpers.symbolStart.ToString() + item.Id + Helpers.productSpaces+ "Name " + item.Name + Helpers.productSpaces+"UnicalCode " + item.UnicCode + Helpers.productSpaces+"Made by" + item.Producer);
        }
        private void AddNewItemToBasket()
        {
            if (string.IsNullOrWhiteSpace(txtCount.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                return;
            int nextIndex = BuyManager.BasketItems.Count();

            BuyManager.AddNewItemToBasket(
                new Buy()
                {
                    Id = nextIndex++,
                    Count = Convert.ToDecimal(txtCount.Text),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    UserName = Session[Sessions.LogedInUserName]?.ToString(),
                    DateTime = DateTime.Now,
                    RetailPrice = Convert.ToDecimal(txtBoxRetailPrice.Text),
                    ProductId = Helpers.GetProductIdFromDropDownSelectedItem(dropDownProducts.SelectedValue)

                }
            );

        }

    
        private void RefreshGridView()
        {
            //GridViewBasket.DataSource = MarketManagment.BuyManager.BasketViewItems;
            GridViewBasket.DataBind();
            FillFooter();
            btnComplateSale.Visible = BuyManager.IsExistItemInBasket;

        }
        private void FillFooter()
        {

            GridViewBasket.FooterRow.HorizontalAlign = HorizontalAlign.Center;
            GridViewBasket.FooterRow.VerticalAlign = VerticalAlign.Middle;

            GridViewBasket.FooterRow.Cells[2].Text = $"COUNT\n{BuyManager.TotalCount }";
            GridViewBasket.FooterRow.Cells[5].Text = $"Retail\n{BuyManager.TotalRetailPrice}";

            GridViewBasket.FooterRow.Cells[6].Text = $"TOTAL\n{BuyManager.TotalMoney}";

        }

        protected void ObjectDataSourceBuyView_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SetBasketComplateVisible();

        }



        protected void ObjectDataSourceBuyView_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SetBasketComplateVisible();

        }

      

        private void SetBasketComplateVisible()
        {
          //  lblBasketTitle.Visible =  ImageButtonComplateOrder.Visible = BuyManager.IsExistItemInBasket;

        }

        protected void ImageButtonComplateOrder_Click(object sender, EventArgs e)
        {
            var _userName = Session[Sessions.LogedInUserName]?? "Debug Mode";

            // Created Without Async because Method  in transaction 
            var isOk = BuyManager.ComplateOrder(BuyManager.BasketItems, _userName.ToString());
            if (!isOk)
                Response.Redirect("~/Error.aspx");
        }

        protected void imgButtonAddToCard_Click(object sender, EventArgs e)
        {
            AddNewItemToBasket();
            RefreshGridView();
        }
    }
}