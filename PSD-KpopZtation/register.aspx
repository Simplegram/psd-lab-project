<%@ Page Title="" Language="C#" MasterPageFile="~/Unauthorized.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PSD_KpopZtation.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbxEmail" runat="server" TextMode="Email"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <asp:Button ID="btnRegister" runat="server" Text="Register" />
</asp:Content>
