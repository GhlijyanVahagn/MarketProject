<%@ Page Language="C#"  MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="MarketProject.View.NewUser.NewUser" Async="true" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">


    <div>
        <h4 style="font-size: medium">Register a new user</h4>
        <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>                
        <div style="margin-bottom:10px">
            <asp:Label runat="server">User name</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtUserName" />                
            </div>
        </div>
          <div style="margin-bottom:10px">
            <asp:Label runat="server" >Email</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtEmail" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" >Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server">Confirm password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" />                
            </div>
        </div>
        <div>
            <div>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
            </div>
        </div>
    </div>
</asp:Content>