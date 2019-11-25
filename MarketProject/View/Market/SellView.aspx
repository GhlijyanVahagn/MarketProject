<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master"    AutoEventWireup="true" CodeBehind="SellView.aspx.cs"    Inherits="MarketProject.View.Market.BuyView"   Async="true"   %>

<asp:Content  ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">
    <div class="backGroundSell">
           <asp:Label CssClass="SalePageTitle" Width="100%" ID="lblTitle" runat="server" Text="Sale Manager"></asp:Label>
          
                <div>
                <asp:Label ID="lblFinProbBY" CssClass="searchLabel" runat="server" Text="Search product by "></asp:Label>

                <asp:RadioButton CssClass="searchRadioButtons" ID="rbnByName" runat="server" Text="Name" GroupName="prod" />

                <asp:RadioButton CssClass="searchRadioButtons" ID="rbnByUnicalCode" runat="server" Text="UnicCode" GroupName="prod"  />

                <asp:RadioButton CssClass="searchRadioButtons" ID="rbnBarCode" runat="server" Text="BarCcode" GroupName="prod"  />

                <asp:RadioButton CssClass="searchRadioButtons" ID="rbnByProducer" runat="server" Text="Producer" GroupName="prod" />
                </div>

                <div>
                    <div class="searchBlock">
                         <asp:Label CssClass="LableStyle" ID="lblFindBy" runat="server" Text="Find"></asp:Label>
                        <asp:TextBox CssClass="buyFindtext" ID="txtSearchString" runat="server" TabIndex="1" ></asp:TextBox>
                        <asp:ImageButton CssClass="btnSearch" ID="btnSearch" runat="server" ImageUrl="~/Resources/search.png" OnClick="btnSearch_Click" />
                    </div>
         
           
                    <asp:Label CssClass="LableStyle" ID="lblProduct" runat="server" Text="Product"></asp:Label>
                    <asp:DropDownList CssClass="buyProdTxtBoxProductDropDownList" ID="dropDownProducts" runat="server">
                    </asp:DropDownList>
                </div>

           
            
            <div class="auto-style3">
                <asp:Label CssClass="LableStyle" ID="lblCount" runat="server" Text="Count"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxCount" ID="txtCount" runat="server" TabIndex="1" OnTextChanged="txtCount_TextChanged" ></asp:TextBox>
            </div>

            <div>
                <asp:Label CssClass="LableStyle" ID="lblPrice" runat="server" Text="Price"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxPrice" ID="txtPrice" runat="server" MaxLength="7" TabIndex="2" OnTextChanged="txtCount_TextChanged"></asp:TextBox>
            </div>

        <div>
                <asp:Label CssClass="LableStyle" ID="lblRetailSalePrice" runat="server" Text="Retail Price"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxRetailPrice" ID="txtBoxRetailPrice" runat="server" MaxLength="9" TabIndex="2" ></asp:TextBox>
            </div>

            <div>
                <asp:Label CssClass="LableStyle" ID="lblDiscount" runat="server" Text="Discount"></asp:Label>
                <asp:TextBox CssClass="buyProdTxtBoxDiscount" ID="txtDiscount" runat="server" MaxLength="7" TabIndex="3"></asp:TextBox>
            </div>
        <div class="divTotal">
                <asp:Label CssClass="TotalMoney" ID="lblTotal" runat="server" Font-Bold="False" Font-Size="Medium" ForeColor="White" Text="Total Price   "></asp:Label>

     
                <asp:Label CssClass="TotalMoney" ID="lbltotalMoney" runat="server"></asp:Label>

     
            </div>
    <div class="buyBasketComplateOrder">
                <asp:Button CssClass="buttonStyle" ID="AddToBasket" runat="server" Text="Add to basket" OnClick="imgButtonAddToCard_Click" />
                <asp:Button CssClass="buttonStyle" Text="Complate Sale " ID="btnComplateSale" runat="server"  OnClick="ImageButtonComplateOrder_Click" Visible="False" />

       
      </div>
        <div class="GridStyle">
            <asp:ObjectDataSource ID="ObjectDataSourceBuyView" runat="server" DeleteMethod="RemoveItemFromBasketById" SelectMethod="ShowBasketViewItems" TypeName="MarketManagment.BuyManager" OnDeleted="ObjectDataSourceBuyView_Deleted" OnInserted="ObjectDataSourceBuyView_Inserted" UpdateMethod="UpdateBasketItemInfo">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="count" Type="Decimal" />
                    <asp:Parameter Name="price" Type="Decimal" />
                    <asp:Parameter Name="Payed" Type="Decimal" />
                    <asp:Parameter Name="Total" Type="Decimal" />
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="RetailPrice" Type="Decimal" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="GridViewBasketSale"
                runat="server" 
                AllowSorting="True" 
                CssClass="auto-style2" 
                Height="197px" 
                HorizontalAlign="Center"
                Width="709px" AllowPaging="True" PageSize="15" ShowFooter="True" AutoGenerateColumns="False" CellPadding="4"  
                ForeColor="#333333" GridLines="None" 
                DataSourceID="ObjectDataSourceBuyView"
                >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Payed" HeaderText="Payed" SortExpression="Payed" />
                    <asp:BoundField DataField="RetailPrice" HeaderText="RetailPrice" SortExpression="RetailPrice" />
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                    <asp:CommandField ControlStyle-CssClass="GridUpdateButtons" ButtonType="Image" DeleteImageUrl="~/Resources/delete-2-xxl.png" ShowDeleteButton="True" />
                    <asp:CommandField ControlStyle-CssClass="GridUpdateButtons" ButtonType="Image" CancelImageUrl="~/Resources/cancel_grid_row_updating.png" EditImageUrl="~/Resources/Edit.png" ShowEditButton="True" UpdateImageUrl="~/Resources/Update_grid_row_editing.png" />
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
    </div>


       
      
      
         
          
         
</asp:Content>