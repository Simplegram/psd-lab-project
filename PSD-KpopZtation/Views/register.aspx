<%@ Page Title="" Language="C#" MasterPageFile="~/Unauthorized.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PSD_KpopZtation.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
        <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbxEmail" runat="server" TextMode="Email"></asp:TextBox>
    </div>
    <div>
        <asp:RadioButtonList ID="rblGender" runat="server">
            <asp:ListItem Selected="True">Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="tbxAddress" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"/>
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
</asp:Content>
