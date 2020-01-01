<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="MarketProject.Error" %>
<asp:Content  ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">

    <div>
    <asp:Image runat="server" ImageUrl="~/Resources/error.png" ImageAlign="Middle"/>
        </div>


        <asp:Label ID="labelInfo" CssClass="ErrorInfo" runat="server"></asp:Label>
</asp:Content>