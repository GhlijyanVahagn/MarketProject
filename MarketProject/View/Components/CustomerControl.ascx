<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerControl.ascx.cs" Inherits="MarketProject.View.Components.CustomerControl" %>
  
        <div class="searchBlock">
                          <h3 style="text-align:center">Customer</h3>
                        Find <asp:TextBox CssClass="buyFindtext" ID="txtSearchString" runat="server" TabIndex="1"  ></asp:TextBox>
                        <asp:ImageButton CssClass="btnSearch" ID="btnSearch" runat="server" ImageUrl="~/Resources/search.png"/>
     <div>Customer<asp:dropdownlist CssClass="buyProdTxtBoxProductDropDownList" Width="150px" id="DropDownCustomer" runat="server" autopostback="True" datatextfield="Value" datavaluefield="Text"  Font-Bold="True"/></div> 
         </div>


