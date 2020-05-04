<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#"  AutoEventWireup="true" CodeBehind="TransactionsView.aspx.cs" Inherits="MarketProject.View.Market.Transactions" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent">


       

 <div>
      <asp:Menu CssClass="TransactionsTab"

        ID="Menu1"

        Width="168px"

        runat="server"

        Orientation="Horizontal"

        StaticEnableDefaultPopOutImage="False"

        OnMenuItemClick="Menu1_MenuItemClick"
        
        >
    <Items  >
        <asp:MenuItem Text="Buy" Selectable="true"  Value="0"></asp:MenuItem>
        <asp:MenuItem Text="Sale" Selectable="true" Value="1"></asp:MenuItem>
       
    </Items>
          <StaticSelectedStyle BackColor="#CCFFFF" />
</asp:Menu>
             <div class="calendarStart">
                  <p class="textCenter">Select  Start Date</p>
            <asp:Calendar  ID="DateStart"  runat="server" SelectionMode="Day"   >    </asp:Calendar>  
                
            </div>
          
        <div class="auto-style4">
              <p class="textCenter">Select  End Date</p>
             <asp:Calendar ID="DateEnd"  runat="server" SelectionMode="Day"> </asp:Calendar>
              <br />
        </div>
          
             
            
              <br/><br/>
     <asp:Button ID="Search" runat="server" Text="Find" OnClick="Search_Click"/>
     
   
    <div >
        <asp:MultiView  ID="MultiView1" runat="server"  ActiveViewIndex="0"  >
             <asp:View ID="Tab1" runat="server" >
                 <asp:GridView ID="GridViewBuyTransactions" runat="server" DataSourceID="ObjectDataSourceBuy" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewBuyTransactions_SelectedIndexChanged1">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                <asp:CommandField ShowSelectButton="True" />

                                <asp:TemplateField></asp:TemplateField>

                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                 </asp:View>

              <asp:View ID="Tab2" runat="server" >
                 <asp:GridView ID="GridViewSaleTransactions" runat="server" DataSourceID="ObjectDataSourceSale" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                 </asp:View>
            </asp:MultiView>


        <%--<asp:MultiView  ID="MultiView1" runat="server"  ActiveViewIndex="0"  >

        <asp:View ID="Tab1" runat="server" >
            <div class="transactionGrid">
                 <table  cellpadding=0 cellspacing=0 >
                <tr valign="top">
                    <td class="TabArea" style="width: 300px" >
                        <asp:GridView ID="GridViewBuyTransactions" runat="server" DataSourceID="ObjectDataSourceBuy" AutoGenerateColumns="False" AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
       
         </asp:View>
        <asp:View ID="Tab2" runat="server">
            <div class="transactionGrid">
                <table  cellpadding=0 cellspacing=0 class="transactionGrid">
                <tr valign="top">
                    <td class="TabArea" style="width: 300px">
                        <asp:GridView ID="GridViewSaleTransactions" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="ObjectDataSourceSale">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
        
        </asp:View>
  
        </asp:MultiView>--%>
    </div>
     
     <div class="transactionDetailesGrid">
            <asp:GridView ID="GridViewDetailes" runat="server" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="ActionDate" HeaderText="ActionDate" SortExpression="ActionDate" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Payed" HeaderText="Payed" SortExpression="Payed" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
                    <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                </Columns>
    
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
    
            </asp:GridView>
     </div>
 </div>

   





    <asp:ObjectDataSource ID="ObjectDataSourceBuy" runat="server" SelectMethod="GetBuyTransactions" TypeName="MarketProject.View.Market.Transactions">
        <SelectParameters>
            <asp:ControlParameter ControlID="DateStart" Name="dateStart" PropertyName="SelectedDate" Type="DateTime" />
            <asp:ControlParameter ControlID="DateEnd" Name="dateEnd" PropertyName="SelectedDate" Type="DateTime" />
        </SelectParameters>
          </asp:ObjectDataSource>
   

          <asp:ObjectDataSource ID="ObjectDataSourceSale" runat="server" SelectMethod="GetSaleTransactions" TypeName="MarketProject.View.Market.Transactions">
              <SelectParameters>
                  <asp:ControlParameter ControlID="DateStart" Name="dateStart" PropertyName="SelectedDate" Type="DateTime" />
                  <asp:ControlParameter ControlID="DateEnd" Name="dateEnd" PropertyName="SelectedDate" Type="DateTime" />
              </SelectParameters>
          </asp:ObjectDataSource>
 
         

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width: 225px;
            height: 250px;
            float: left;
            margin-left: 0px;
        }
    </style>
</asp:Content>
