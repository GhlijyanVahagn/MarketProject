<%@ Page Language="C#"  MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewCustomer.aspx.cs" Inherits="MarketProject.View.AdminPanel.NewCustomer" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">

  <div style="padding:5px; margin:10px;">  
      <p>Create Customer</p><br/>
      <div style="padding:5px; margin:10px;">
            Name<asp:TextBox ID="CustomerNametxt" runat="server"></asp:TextBox>
      </div>
      <div style="padding:5px; margin:10px;">
        <br/>Surname<asp:TextBox ID="Surnametxt" runat="server"></asp:TextBox>
    </div >
      <div style="padding:5px; margin:10px;">
        <br/>Gender<asp:DropDownList ID="dropDownGender" runat="server" Height="17px" Width="130px">
              <asp:ListItem>Mail</asp:ListItem>
              <asp:ListItem>Femail</asp:ListItem>
          </asp:DropDownList>
    </div>
      <div style="padding:5px; margin:10px;">
        <br/>Birthday<asp:TextBox ID="birthdaytxt" runat="server"></asp:TextBox>
     </div>
      <div style="padding:5px; margin:10px;">
        <br/>Email<asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
      </div>
      <div style="padding:5px; margin:10px;">
         <br/>Phone<asp:TextBox ID="phonetxt" runat="server"></asp:TextBox>
    </div>
      <div style="padding:5px; margin:10px;">
        <br/>Address<asp:TextBox ID="Addresstxt" runat="server"></asp:TextBox>
     </div>
       <div style="padding:5px; margin:10px;">
        <br/>Description<asp:TextBox ID="DescriptionText"  runat="server" Height="47px" TextMode="MultiLine"></asp:TextBox>
     </div>


      <div style="padding:5px; margin:10px;">
    <br/><asp:Button ID="createNewCustomer" runat="server" Text="Create" OnClick="createNewCustomer_Click" />
          <br />
          <br />
          <asp:Label ID="errorLabel" CssClass="ValidationError" runat="server"></asp:Label>
   </div>
  </div>


    </asp:Content>