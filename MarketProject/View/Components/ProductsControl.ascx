<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsControl.ascx.cs" Inherits="MarketProject.View.Components.ProductsControl"%>


<div class="searchBlock">

   
          <h3 style="text-align:center">Products</h3>
                <div>
                    <asp:Label ID="lblFinProbBY" CssClass="searchLabel" runat="server" Text="Search product by "></asp:Label>
                     <asp:dropdownlist   CssClass="buyProdTxtBoxProductDropDownList" 
                                         id="dropDownSearchCriteria" 
                                         runat="server" 
                                         autopostback="True" 
                                         datatextfield="Value"
                                         datavaluefield="Text" 
                                         OnSelectedIndexChanged="dropDownSearchCriteria_SelectedIndexChanged"  
                                         Font-Bold="True">
                     </asp:dropdownlist>    
             
                </div>

                <div>
                    <div >
                         <asp:Label CssClass="LableStyle" ID="lblFindBy" runat="server" Text="Find"></asp:Label>
                        <asp:TextBox CssClass="buyFindtext" ID="txtSearchString" runat="server" TabIndex="1"  ></asp:TextBox>
                        <asp:ImageButton CssClass="btnSearch" ID="btnSearch" runat="server" ImageUrl="~/Resources/search.png" OnClick="btnSearch_Click" />
                    </div>
         
                    <asp:Label CssClass="LableStyle" ID="lblProduct" runat="server" Text="Product"></asp:Label>
                  
               



        <asp:dropdownlist CssClass="buyProdTxtBoxProductDropDownList" id="DropDownProducts" runat="server" autopostback="True" datatextfield="Value"
        datavaluefield="Text" OnSelectedIndexChanged="DropDownProducts_SelectedIndexChanged" OnTextChanged="DropDownProducts_TextChanged" Font-Bold="True">
    </asp:dropdownlist>    
                </div>
</div>

