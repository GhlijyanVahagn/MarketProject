<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="MarketProject.View.Market.Warehouse" Async="true" %>

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
                ForeColor="#333333" GridLines="None" 
        
        >
          <Columns>
              <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
              <asp:BoundField DataField="UnicCode" HeaderText="UnicCode" SortExpression="UnicCode" />
              <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode" />
              <asp:BoundField DataField="RemindTotal" HeaderText="RemindTotal" SortExpression="RemindTotal" />
              <asp:BoundField DataField="RetailPrice" HeaderText="RetailPrice" SortExpression="RetailPrice" />
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

  
    <asp:ObjectDataSource 
        ID="ObjectDataSourceWarehouse" 
        runat="server" SelectMethod="GetRemindProductsFromWarehouseSearch" TypeName="MarketManagment.Warehouses.WareHouseManagment" 
       
        >
        <SelectParameters>
            <asp:ControlParameter ControlID="txtProductName" Name="filter" PropertyName="Text" Type="String" />
        </SelectParameters>
      
        
    </asp:ObjectDataSource>
</asp:Content>