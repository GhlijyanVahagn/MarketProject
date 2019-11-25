<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="ProductGroupView.aspx.cs" Inherits="MarketProject.View.AdminPanel.ProductGroupView"  Async="true"%>
<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">

        <div>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_GroupName" runat="server" BackColor="White" ControlToValidate="txtName" ErrorMessage="* Is Empty" ForeColor="Red"></asp:RequiredFieldValidator>
         
        </div>
        <div>
            <asp:Label ID="lblName0" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
           
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="215px" OnClick="btnSave_Click" />
        </div>
   </asp:Content>