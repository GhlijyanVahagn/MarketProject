<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="WarehouseView.aspx.cs" Inherits="MarketProject.View.Market.WarehouseView" Async="true" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">
    <h3>Warehouse</h3>
    <hr />

    <p>Displayed all products in warehouse</p>

    <div class="searchBlock">
        <asp:TextBox runat="server" ID="txtProductName" CssClass="buyFindtext"></asp:TextBox>
        <asp:ImageButton runat="server" ID="btnFind" Text="Find" CssClass="btnSearch" ImageUrl="~/Resources/search.png" OnClick="btnFind_Click"/>
    </div>
      <div>
    <asp:GridView ID="GridView1" 
        runat="server" DataSourceID="ObjectDataSourceWarehouse"
        
        
                 AllowSorting="True" 
                CssClass="GridStyle" 
              
                HorizontalAlign="Center"
                 AllowPaging="True" PageSize="15" ShowFooter="True" AutoGenerateColumns="False" CellPadding="4"  
                ForeColor="#333333" GridLines="None" CellSpacing="2" 
        
        >
          <Columns>
              <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
              <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
              <asp:BoundField DataField="Remind" HeaderText="Total Remind" SortExpression="TotalRemind" />

              <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
              <asp:BoundField DataField="RetailSalePrice" HeaderText="Retail Sale Price" SortExpression="RetailSalePrice" />
              <asp:BoundField DataField="WholeSalePrice" HeaderText="WholeSale Price" SortExpression="WholeSalePrice" />

              <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
              <asp:BoundField DataField="BarCode" HeaderText="Producer" SortExpression="BarCode" />

              <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
              <asp:BoundField DataField="Group" HeaderText="Group" SortExpression="Group" />
              <asp:BoundField DataField="Producer" HeaderText="Producer" SortExpression="Producer" />
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
          <asp:ObjectDataSource ID="ObjectDataSourceWarehouse" runat="server" SelectMethod="GetWarehouses" TypeName="MarketProject.View.Market.WarehouseView"></asp:ObjectDataSource>
    </div>

  
    </asp:Content>