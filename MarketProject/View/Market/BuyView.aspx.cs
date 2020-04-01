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

        private DataBinder dataBinder = new DataBinder();

        BasketManager basketManager;
        BuyManager buyManager;
        public Basket basketSession
        {
            get
            {
                return (Basket)Session["basket"];
            }

            set
            {
                Session["basket"] = value;
            }
        }
        //private void ShowPopup(object sender, EventArgs e)
        //{
           
        //}
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!UsersManager.IsUserAutorized)
                Response.Redirect("~/Login.aspx");

            if(!IsPostBack)
            {
                txtCount.AutoPostBack = true;
                txtPrice.AutoPostBack = true;

                //Button1.Click += ShowPopup;


                //if ((List<BasketItem>)Session["basketItemsCollection"] == null && BasketItems == null)
                //    BasketItems = new List<BasketItem>();

            }

            if (basketManager==null)
            {
                basketManager = new BasketManager();
                basketManager.Basket = (Basket)Session["basket"];
                if (basketManager.Basket == null)
                    basketManager.Basket = new Basket();
            }
            //if (basketManager.Basket.BasketItems != null && basketManager.Basket.BasketItems.Count > 0)
                //RefreshGridView();
            //SetBasketComplateVisible();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void fillProductsDropDown()
        {
            //var prodList = MarketManagment.Products.ProductsLocal.LocalProducts;
            //if(prodList==null || prodList.Count()==0)
            //{
            //    //prodList = await ProductManager.GetALLProductDetailInfo();
            //    //MarketManagment.Products.ProductsLocal.LocalProducts= prodList;

            //}
            //InsertIntoDropDown(prodList);

        }

        private decimal SuggestLastSalePrice(int productId,decimal price)
        {
            return 0;
           //return ProductManager.GetLastSalePriceByProductId(productId,price);
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

      


        protected  void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //IEnumerable<ProductView> result=null;
            //if (rbnByName.Checked)
            //    result = ProductManager.GetProductByName(txtSearchString.Text);
            //else if(rbnByUnicalCode.Checked)
            //    result = ProductManager.GetProductByUnicCode(txtSearchString.Text);
            //else if (rbnByProducer.Checked)
            //    result = ProductManager.GetProductByProducerName(txtSearchString.Text);
            //else if(rbnBarCode.Checked)
            //    result = ProductManager.GetProductByBarCode(txtSearchString.Text);

            //InsertIntoDropDown(result);



        }
        private void ClearDropDownList()
        {
        }
        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void InsertIntoDropDown(IEnumerable<ProductViewModel> prodList)
        {
       
            if (prodList == null || prodList.Count() == 0)
                return;
         //   dropDownProducts.Items.Clear();
         //   dropDownProducts.Items.Insert(0, "Select product");


            int index = 1;
            //foreach (var item in prodList)
            //    dropDownProducts.Items.Insert(index++, Helpers.symbolStart.ToString() + item.Id + Helpers.productSpaces+ "Name " + item.Name + Helpers.productSpaces+"UnicalCode " + item.UnicCode + Helpers.productSpaces+"Made by" + item.Producer);
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
                Price = Convert.ToDecimal(txtPrice.Text)

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
            //basketSession = basketManager.Basket;
            RefreshGridView();

        }


        private void RefreshGridView()
        {
            GridViewBasket.DataBind();

            //FillFooter();
            //ObjectDataSourceBuyView.Select();
            //ImageButtonComplateOrder.Visible = buttonCancel.Visible = BuyManager.IsExistItemInBasket;

        }
        //private void FillFooter()
        //{
        //    if(GridViewBasket.FooterRow!=null)
        //    {
        //        GridViewBasket.FooterRow.HorizontalAlign = HorizontalAlign.Center;
        //        GridViewBasket.FooterRow.VerticalAlign = VerticalAlign.Middle;

        //        //GridViewBasket.FooterRow.Cells[2].Text = $"COUNT\n{BuyManager.TotalCount }";
        //        //GridViewBasket.FooterRow.Cells[5].Text = $"Retail\n{BuyManager.TotalRetailPrice}";

        //        //GridViewBasket.FooterRow.Cells[6].Text = $"TOTAL\n{BuyManager.TotalMoney}";
        //    }


        //}

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
            ImageButtonComplateOrder.Visible = true;// basketManager.Basket.IsEmpty;

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
            //txtCount.Text = string.Empty;
            //txtBoxRetailPrice.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            //txtPrice.Text = string.Empty;
            //txtSearchString.Text = string.Empty;
        }

        protected void canel_Click(object sender, EventArgs e)
        {
            //BuyManager.ClearBasket();
            RefreshGridView();
            ClearBoardFields();
        }

        protected void GridViewBasket_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //var Id = int.Parse(GridViewBasket.Rows[e.RowIndex].Cells[0].Text);

            //basketSession.BasketItems.RemoveAt(Id);

            //GridViewBasket.Rows[e.RowIndex].Visible = false;
            //var a=GridViewBasket.Rows[e.RowIndex].Cells[0].Text;
        }

        protected void GridViewBasket_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewBasket_Sorting(object sender, GridViewSortEventArgs e)
        {

            //var ds=basketSession.BasketItems.OrderByDescending(x => x.Price);
            //GridViewBasket.DataSource = ds.ToList();
            //GridViewBasket.DataBind();

  
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


        }
        #endregion

        protected void Button1_Command(object sender, CommandEventArgs e)
        {

        }
    }
}