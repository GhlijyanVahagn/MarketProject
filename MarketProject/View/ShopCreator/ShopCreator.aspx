<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopCreator.aspx.cs" Inherits="MarketProject.View.ShopCreator.ShopCreator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/CSS/ShopCreatorStyle.css"/>
</head>
<body>
    
        <div>
            <asp:Image CssClass="banner" runat="server" ImageUrl="~/Resources/Banner.png" />
        </div>
      <div class="Title">
           <h3>Create your Shop</h3>
      </div>
    <form id="form1" runat="server">
        <div class="Title">
            <div>
                <asp:Label CssClass="LableStyle" Text="shop name" runat="server"> </asp:Label>
                <asp:TextBox CssClass="textBoxStyle" Text="Shop suffix" runat="server"> </asp:TextBox>
             </div>

             <div>
                <asp:Label CssClass="LableStyle" Text="Shop email" runat="server"> </asp:Label>
                <asp:TextBox CssClass="textBoxStyle" id="txtShopEmal" runat="server"> </asp:TextBox>
             </div>
            <br/>
            <br/>
            <br/>
            <br/>

            <div>
                <asp:Label CssClass="LableStyle" Text="Type shop web name " runat="server"> </asp:Label>
                <asp:TextBox CssClass="textBoxStyle" id="txtShopDomainName" runat="server"> </asp:TextBox><br />
               
                <br />
                <asp:Label CssClass="LableStyle" Text="Web address will be " runat="server"> </asp:Label>
                <asp:Image ID="Image1" runat="server" />
                <br />
              
                <div>
                <asp:Button runat="server" Text="Register" CssClass="buttonStyle"/>
                    </div>
            </div>


         

        </div>
    </form>
</body>
</html>
