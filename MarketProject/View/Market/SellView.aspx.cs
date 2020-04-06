using DbModel;
using DbModel.ViewModel;
using MarketHelpers;
using MarketManagment.User;
using MarketManagment.Products;
using MarketManagment.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DbModel.Model.BasketModel;
using MarketManagment.Managers.BasketManagers;

namespace MarketProject.View.Market
{
    public partial class SellView : System.Web.UI.Page
    {
        IEnumerable<ProductViewModel> saleProducts = new List<ProductViewModel>();

        BasketManager basketManager;
        SaleManager SaleManager;

        public Basket basketSession
        {
            get
            {
                return (Basket)Session["basketSaleAction"];
            }

            set
            {
                Session["basketSaleAction"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

            if(!IsPostBack)
            {
                txtCount.AutoPostBack = true;
                txtPrice.AutoPostBack = true;

            }
            if (basketManager == null)
            {
                basketManager = new BasketManager();
                basketManager.Basket = (Basket)Session["basketSaleAction"];
                if (basketManager.Basket == null)
                    basketManager.Basket = new Basket();
            }
            SetBasketComplateVisible();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (ProductsControl.IsProductChanged)
            {
                ClearBoardFields();
            }
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

      


     
        
        protected void TxtCount_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

    
        private void AddNewItemToBasket()
        {
            if (string.IsNullOrWhiteSpace(txtCount.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                return;
            int nextIndex = SaleManager.BasketItems.Count();
            var _userName = Session[Sessions.LogedInUserName] ?? "Debug Mode";

            decimal _price, _count, _discount;
            decimal.TryParse(txtCount.Text, out _count);
            decimal.TryParse(txtPrice.Text, out _price);
            decimal.TryParse(txtDiscount.Text, out _discount);

            if(_count<=0)
            {
                Response.Redirect("~/error.aspx");
            }
            var basketItem = new BasketItem()
            {
                Id = basketManager.Basket.BasketItemsCount,
                Count = Convert.ToDecimal(txtCount.Text),
                ProductId = ProductsControl.SelectedProductId,
                Price = Convert.ToDecimal(txtPrice.Text),
            };
            basketItem.Product = ((IEnumerable<ProductViewModel>)Session["Products"]).FirstOrDefault(x => x.Id == basketItem.ProductId);
            if (basketManager.Basket.BasketItems.FirstOrDefault(x => x.ProductId == basketItem.ProductId) != null)
            {

                panelPopup.Visible = true;
                modalPopup.Show();
                return;
            }
            basketManager.Basket.BasketItems.Add(basketItem);

            basketSession = basketManager.Basket;
            
            RefreshGridView();
            SetBasketComplateVisible();
            ClearBoardFields();
           

        }

    
        private void RefreshGridView()
        {
            //GridViewBasket.DataSource = MarketManagment.BuyManager.BasketViewItems;
            GridViewBasketSale.DataBind();
            FillFooter();
            btnComplateSale.Visible = ButtonCancel.Visible= SaleManager.IsExistItemInBasket;

        }
        private void FillFooter()
        {

            //GridViewBasketSale.FooterRow.HorizontalAlign = HorizontalAlign.Center;
            //GridViewBasketSale.FooterRow.VerticalAlign = VerticalAlign.Middle;
     
            //GridViewBasketSale.FooterRow.Cells[2].Text = $"COUNT\n{SaleManager.TotalCount }";
            ////GridViewBasketSale.FooterRow.Cells[5].Text = $"Retail\n{SaleManager.TotalRetailPrice}";

            //GridViewBasketSale.FooterRow.Cells[6].Text = $"TOTAL\n{SaleManager.TotalMoney}";

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

            else
            {
                SaleManager.ClearBasketItems();
                RefreshGridView();
                ClearBoardFields();
            }
        }

        protected void ImgButtonAddToCard_Click(object sender, EventArgs e)
        {
            AddNewItemToBasket();
            RefreshGridView();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            SaleManager.ClearBasketItems();
            RefreshGridView();
            ClearBoardFields();
        }
        private void ClearBoardFields()
        {

            txtCount.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtPrice.Text = string.Empty;
         
        }

    
    }
}