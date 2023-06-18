<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Unauthorized.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PSD_KpopZtation.Views.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 95vh; display: flex; flex-direction: column; justify-content: center; align-items: center;">
        <div class="column">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbxEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="cbxRemember" runat="server"/>
            <asp:Label ID="lblRemember" runat="server" Text="Remember me"></asp:Label>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
