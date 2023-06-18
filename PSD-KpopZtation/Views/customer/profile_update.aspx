<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Customer.Master" AutoEventWireup="true" CodeBehind="profile_update.aspx.cs" Inherits="PSD_KpopZtation.Views.customer.profile_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; align-items: center">
        <div class="column">
            <asp:Label ID="lblCustomerName" runat="server"><b>Name</b></asp:Label>
            <asp:TextBox ID="tbxCustomerName" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblCustomerEmail" runat="server"><b>Email</b></asp:Label>
            <asp:TextBox ID="tbxCustomerEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div class="column">
            <asp:RadioButtonList ID="rblCustomerGender" runat="server">
            <asp:ListItem Selected="True">Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        </div>
        <div class="column">
            <asp:Label ID="lblCustomerAddress" runat="server"><b>Address</b></asp:Label>
            <asp:TextBox ID="tbxCustomerAddress" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblCustomerPass" runat="server"><b>Password</b></asp:Label>
            <asp:TextBox ID="tbxCustomerPass" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update/Change Profile" OnClick="btnUpdate_Click"/>
        <asp:Literal ID="ltrlStatus" runat="server"></asp:Literal>
    </div>
</asp:Content>
