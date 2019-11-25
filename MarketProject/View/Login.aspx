<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MarketProject.Login" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="WebPageContent" ViewStateMode="Enabled">

                            <asp:Panel ID="Panel1" runat="server" Height="445px">
                                <div class="auto-style1">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="lbllogin0" runat="server" Font-Bold="True" Text="Please Login"></asp:Label>
                                    <br />
                                    <br />
                                   Login
                                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin" ErrorMessage="* Login Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                   Password
                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="* Password required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSignIn" runat="server" OnClick="Button1_Click" Text="Sign In" Width="97px" />
                                    <br /><br />
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                            </asp:Panel>
        <div>
        </div>
    </asp:Content>