using DbModel;
using MarketHelpers;
using MarketManagment;
using MarketManagment.Products;
using MarketManagment.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MarketProject.View.Market
{
    public partial class SellView : System.Web.UI.Page
    {



        IEnumerable<ProductView> saleProducts = new List<ProductView>();
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
           
            if(saleProducts == null || saleProducts.Count()==0)
            {
                saleProducts = await ProductManager.GetAllRemindProductsDetailInfo();
            }
            InsertIntoDropDown(saleProducts);

        }

        private void CalculatePrice()
        {
            decimal price, count,discount;
            decimal.TryParse(txtPrice.Text.Trim(), out price);
            decimal.TryParse(txtCount.Text.Trim(), out count);
            decimal.TryParse(txtDiscount.Text.Trim(), out discount);

            if (price > 0 && count > 0)
                lbltotalMoney.Text = $"{price * count- price * count*discount/100} {UsersManager.Currency}";
        }

      


        protected async void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            IEnumerable<ProductView> result=null;
            if (rbnByName.Checked)
                result = await ProductManager.GetProductInfoByNameFromDbAsync(txtSearchString.Text);
            else if(rbnByUnicalCode.Checked)
                result =await ProductManager.getProductInfoByUnicCodeFromDbAsync(txtSearchString.Text);
            else if (rbnByProducer.Checked)
                result =await ProductManager.getProductInfoByUnicCodeFromDbAsync(txtSearchString.Text);
            else if(rbnBarCode.Checked)
                result =await ProductManager.getProductInfoByBarcodeFromDbAsync(txtSearchString.Text);

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
            GridViewBasketSale.DataBind();
            FillFooter();
            btnComplateSale.Visible = BuyManager.IsExistItemInBasket;

        }
        private void FillFooter()
        {

            GridViewBasketSale.FooterRow.HorizontalAlign = HorizontalAlign.Center;
            GridViewBasketSale.FooterRow.VerticalAlign = VerticalAlign.Middle;
     
            GridViewBasketSale.FooterRow.Cells[2].Text = $"COUNT\n{BuyManager.TotalCount }";
            GridViewBasketSale.FooterRow.Cells[5].Text = $"Retail\n{BuyManager.TotalRetailPrice}";

            GridViewBasketSale.FooterRow.Cells[6].Text = $"TOTAL\n{BuyManager.TotalMoney}";

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
            var isOk = SaleManager.ComplateSaleOrder(SaleManager.BasketItems, _userName.ToString());
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