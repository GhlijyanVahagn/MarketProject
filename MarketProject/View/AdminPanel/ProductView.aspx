<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="MarketProject.View.AdminPanel.ProductView"  Async="true"%>
<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">



        <div class="auto-style1">
            <div class="auto-style2">
                                  
            <asp:Label ID="Label1" runat="server" Text="Create New Product"></asp:Label>
            <br />
            <br />
            <br />
            <br />
                              <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
           
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="* Please Fill" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
                               <asp:Label ID="lblUnicCode" runat="server" Text="UnicCode"></asp:Label>
     
            <asp:TextBox ID="txtUnicalCode" runat="server"></asp:TextBox>
  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnicalCode" ErrorMessage="* Please Fill" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
              
            <asp:Label ID="lbBarCode" runat="server" Text="BarCode"></asp:Label>
      
            <asp:TextBox ID="txtBarCode" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
                               <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
              
            <asp:DropDownList ID="comboUnit" runat="server">
            </asp:DropDownList>
   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="comboUnit" ErrorMessage="* Please Choose" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
                               <asp:Label ID="lblGroup" runat="server" Text="Group"></asp:Label>
          
            <asp:DropDownList ID="comboGroup" runat="server">
            </asp:DropDownList>
 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="comboGroup" ErrorMessage="* Please Choose" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
                               
            <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
       
            <asp:DropDownList ID="comboCountry" runat="server">
            </asp:DropDownList>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="comboCountry" ErrorMessage="* Please Choose" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
                                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
   
            <asp:TextBox ID="txtDescription" runat="server" Height="49px" TextMode="MultiLine" Width="239px"></asp:TextBox>
                <asp:Label ID="CustomerError" CssClass="ValidationError" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
                       
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="199px" />
                <br />
                <br />
            </div>
            <asp:GridView ID="gridProduct" runat="server" AllowPaging="True" AllowSorting="True" OnRowEditing="gridProduct_RowEditing" OnRowDeleting="gridProduct_RowDeleting" PageSize="20" Width="285px">
                <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <Columns>
                    <asp:CommandField ButtonType="Image" DeleteText="" EditImageUrl="~/Resources/Edit.png"  EditText="" ShowEditButton="True" ShowHeader="True">
                    <ItemStyle Width="24px" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Resources/delete-2-xxl.png" DeleteText="" ShowDeleteButton="True"></asp:CommandField>
                </Columns>
                <HeaderStyle BackColor="#FF9900" BorderStyle="Solid" />
                <SelectedRowStyle BackColor="#FF9900" />
            </asp:GridView>
        </div>
</asp:Content>
