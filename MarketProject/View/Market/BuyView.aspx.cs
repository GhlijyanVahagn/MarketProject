using DbModel;
using DbModel.ViewModel;
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
using DbModel.Model.BasketModel;
using MarketManagment.Managers.BasketManagers;
using System.ComponentModel;
using MarketManagment.User;

namespace MarketProject.View.Market
{
    public partial class BuyView : System.Web.UI.Page
    {


        BasketManager basketManager;
        BuyManager buyManager;
        public Basket basketSession
        {
            get
            {
                return (Basket)Session["basketBuyAction"];
            }

            set
            {
                Session["basketBuyAction"] = value;
            }
        }
        #region ObjectDataSource Methods Dont Remove
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public List<BasketItem> GetItems()
        {
            if (basketSession != null)
                return basketSession.BasketItems;
            else
                return null;
        }


        public void RemoveItem(int Id)
        {
            basketSession.BasketItems.RemoveAt(Id);
            SetBasketComplateVisible();


        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

            if(!IsPostBack)
            {
                txtCount.AutoPostBack = true;
                txtPrice.AutoPostBack = true;
            }

            if (basketManager==null)
            {
                basketManager = new BasketManager();
                basketManager.Basket = (Basket)Session["basketBuyAction"];
                if (basketManager.Basket == null)
                    basketManager.Basket = new Basket();
            }
            //if (basketManager.Basket.BasketItems != null && basketManager.Basket.BasketItems.Count > 0)
                //RefreshGridView();
            SetBasketComplateVisible();

           
         
        }
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            if (ProductsControl.IsProductChanged)
            {
                ClearBoardFields();
            }
        }


        private void CalculatePrice()
        {
            decimal price, count;
            decimal.TryParse(txtPrice.Text.Trim(), out price);
            decimal.TryParse(txtCount.Text.Trim(), out count);


            if (price > 0 && count > 0)
            {
                lbltotalMoney.Text = $"{price * count} {UsersManager.Currency}";
                //var productId = Helpers.GetProductIdFromDropDownSelectedItem(dropDownProducts.SelectedValue);
                //var lastRetailPrie=SuggestLastSalePrice(productId,price);
              //  txtBoxRetailPrice.Text = lastRetailPrie>0? lastRetailPrie.ToString():string.Empty;
            }

        }
        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

       
        private void AddNewItemToBasket()
        {

            if (string.IsNullOrWhiteSpace(txtCount.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                return;
            var basketItem = new BasketItem()
            {
                Id = basketManager.Basket.BasketItemsCount,
                Count = Convert.ToDecimal(txtCount.Text),
                ProductId = ProductsControl.SelectedProductId,
                Price = Convert.ToDecimal(txtPrice.Text),
        
                RetailPrice= Convert.ToDecimal(txtBoxRetailPrice.Text),
                WholeSalePrice=Convert.ToDecimal(txtWholeSalePrice.Text)

            };
            basketItem.Product = ((IEnumerable<ProductViewModel>)Session["Products"]).FirstOrDefault(x => x.Id == basketItem.ProductId);
            if(basketManager.Basket.BasketItems.FirstOrDefault(x=>x.ProductId== basketItem.ProductId)!=null)
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
            GridViewBasket.DataBind();
            FillFooter();
        }
        private void FillFooter()
        {
            if (GridViewBasket.FooterRow != null)
            {
                GridViewBasket.FooterRow.HorizontalAlign = HorizontalAlign.Center;
                GridViewBasket.FooterRow.VerticalAlign = VerticalAlign.Middle;

                BasketCalculation calculation = new BasketCalculation(basketSession);

                GridViewBasket.FooterRow.Cells[2].Text = calculation.TotalCount.ToString();
                GridViewBasket.FooterRow.Cells[4].Text = calculation.TotalPrice.ToString();


                
            }


        }
        private void SetBasketComplateVisible()
        {
            if(basketSession!=null)
            {
                bool isVisible = !basketSession.IsEmpty;
                ImageButtonComplateOrder.Visible = isVisible;
                buttonCancel.Visible = isVisible;
            }
     
        }

        protected void ImageButtonComplateOrder_Click(object sender, EventArgs e)
        {
            //var _userName = Session[Sessions.LogedInUserName]?? "Debug Mode";

    
            buyManager = new BuyManager(basketManager);
            
            var message=   buyManager.ComplateOrder();
            if (message != "")
                Response.Redirect($"~/Error.aspx?error={message}");
            else
            {
                basketManager.ClearBasket();
                RefreshGridView();
                ClearBoardFields();

            }
        }

        protected void ImgButtonAddToCard_Click(object sender, EventArgs e)
        {
            AddNewItemToBasket();
            
        }
        private void ClearBoardFields()
        {
            txtCount.Text = string.Empty;
            txtBoxRetailPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtWholeSalePrice.Text = string.Empty;
        }

        protected void canel_Click(object sender, EventArgs e)
        {
            basketSession = null;
            RefreshGridView();
            ClearBoardFields();


   
        }
        
   
    }
}