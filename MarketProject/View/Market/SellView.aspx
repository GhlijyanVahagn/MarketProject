﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master"    AutoEventWireup="true" CodeBehind="SellView.aspx.cs"    Inherits="MarketProject.View.Market.SellView"   Async="true"   %>
<%@ Register Src="~/View/Components/ProductsControl.ascx" TagPrefix="uc1" TagName="ProductsControl" %>
<%@ Register Src="~/View/Components/CustomerControl.ascx" TagPrefix="uc2" TagName="CustomerControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content  ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">

           <asp:Label CssClass="SalePageTitle" Width="100%" ID="lblTitle" runat="server" Text="Sale Manager"></asp:Label>
         
        <div class="split left">
        
              <div>
                    <uc1:ProductsControl  runat="server" id="ProductsControl" />
             </div>
            <div>
                    <uc2:CustomerControl  runat="server" id="CustomerControl" />
             </div>
           
            <div class="searchBlock">
                <div class="auto-style3">
                <asp:Label CssClass="LableStyle" ID="lblCount" runat="server" Text="Count"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxCount" ID="txtCount" runat="server" TabIndex="1" OnTextChanged="TxtCount_TextChanged" ></asp:TextBox>
            </div>

            <div>
                <asp:Label CssClass="LableStyle" ID="lblPrice" runat="server" Text="Price"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxPrice" ID="txtPrice" runat="server" MaxLength="7" TabIndex="2" OnTextChanged="TxtCount_TextChanged"></asp:TextBox>
            </div>

      

            <div>
                <asp:Label CssClass="LableStyle" ID="lblDiscount" runat="server" Text="Discount"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxDiscount" ID="txtDiscount" runat="server" MaxLength="7" TabIndex="3"></asp:TextBox>
            </div>
        <div class="divTotal">
                <asp:Label CssClass="TotalMoney" ID="lblTotal" runat="server" Font-Bold="False" Font-Size="Medium" ForeColor="White" Text="Total Price   "></asp:Label>

     
                <asp:Label CssClass="TotalMoney" ID="lbltotalMoney" runat="server"></asp:Label>

     
            </div>
            </div>
            
                            <asp:Button CssClass="buttonStyle" ID="AddToBasket" runat="server" Text="Add to basket" OnClick="ImgButtonAddToCard_Click" />

               </div>


        <div class="split right">
              <div class="GridStyle">
            <asp:ObjectDataSource ID="ObjectDataSourceBuyView" runat="server" SelectMethod="GetItems" TypeName="MarketProject.View.Market.SellView" OnDeleted="ObjectDataSourceBuyView_Deleted" OnInserted="ObjectDataSourceBuyView_Inserted" DeleteMethod="RemoveItem">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="GridViewBasketSale"
                runat="server" 
                AllowSorting="True" 
                CssClass="auto-style2" 
                Height="197px" 
                HorizontalAlign="Center"
                Width="709px" AllowPaging="True" PageSize="15" ShowFooter="True" AutoGenerateColumns="False" CellPadding="4"  
                ForeColor="#333333" GridLines="None" 
                DataSourceID="ObjectDataSourceBuyView" AutoGenerateDeleteButton="True" CellSpacing="1"
                >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="BasketItemId" HeaderText="BasketItemId" SortExpression="BasketItemId" Visible="False" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" ReadOnly="True" SortExpression="ProductName" />
                    <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" Visible="False" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
                    <asp:BoundField DataField="RetailPrice" HeaderText="RetailPrice" SortExpression="RetailPrice" />
                    <asp:BoundField DataField="WholeSalePrice" HeaderText="WholeSalePrice" SortExpression="WholeSalePrice" Visible="False" />
                    <asp:BoundField DataField="Payed" HeaderText="Payed" SortExpression="Payed" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle  BackColor="#507CD1" Font-Bold="True" Font-Size="Large" HorizontalAlign="Right" ForeColor="White"  />
                <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <PagerSettings NextPageText="Next &gt;" PreviousPageText="&lt; Previous" />
                <PagerStyle BorderColor="#DCDADB" HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                   </div>
          <div class="DivToCenter">
                  <asp:Button CssClass="buttonStyle" Text="Complate Sale " ID="btnComplateSale" runat="server"  OnClick="ImageButtonComplateOrder_Click" />
                  <asp:Button CssClass="buttonStyle" Text="Cancel Sale " ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" />
        
        </div>
            </div>
 
      



      <asp:Button ID="popupShowButton" CssClass="InvisibleButton" runat="server" />
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
<cc1:ModalPopupExtender ID="modalPopup" runat="server" PopupControlID="panelPopup" TargetControlID="popupShowButton"
    CancelControlID="popupCloseButton" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="panelPopup" runat="server" CssClass="modalPopup"  Visible="false">
    <iframe  id="irm1" src="~/Popup/Attention.aspx" runat="server" ></iframe>
   <br/>
    <asp:Button ID="popupCloseButton" runat="server" Text="x" />
</asp:Panel> 
      
      
         
          
         
</asp:Content>