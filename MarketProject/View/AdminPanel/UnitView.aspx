<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="UnitView.aspx.cs" Inherits="MarketProject.View.AdminPanel.UnitView" Async="true" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">




   <%-- <form id="form1" runat="server">--%>
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Unit Manager"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Save" Width="235px" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="gridUnit" runat="server" Width="375px" >
            </asp:GridView>
         
            <br />
        </div>
  <%--  </form>--%>

</asp:Content>
