<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsControl.ascx.cs" Inherits="MarketProject.View.Components.ProductsControl"%>


<div>

   
          
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
                        <asp:TextBox CssClass="buyFindtext" ID="txtSearchString" runat="server" TabIndex="1"  ></asp:TextBox>
                        <asp:ImageButton CssClass="btnSearch" ID="btnSearch" runat="server" ImageUrl="~/Resources/search.png" OnClick="btnSearch_Click" />
                    </div>
         
                    <asp:Label CssClass="LableStyle" ID="lblProduct" runat="server" Text="Product"></asp:Label>
                  
               



        <asp:dropdownlist CssClass="buyProdTxtBoxProductDropDownList" id="DropDownProducts" runat="server" autopostback="True" datatextfield="Value"
        datavaluefield="Text" OnSelectedIndexChanged="DropDownProducts_SelectedIndexChanged" OnTextChanged="DropDownProducts_TextChanged" Font-Bold="True" Width="200px" >
    </asp:dropdownlist>    
                </div>
</div>

