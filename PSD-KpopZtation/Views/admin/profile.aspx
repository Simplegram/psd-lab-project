<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h2>Here is your profile, <asp:Literal ID="ltrlNamaUser" runat="server"></asp:Literal></h2>
        </div>
        <div>
            <div class="column">
                <asp:Label ID="lblEmail" runat="server"><b>Email Address</b></asp:Label>
                <p><asp:Literal ID="ltrlEmail" runat="server"></asp:Literal></p>
            </div>
            <div class="column">
                <asp:Label ID="lblGender" runat="server"><b>Gender</b></asp:Label>
                <p><asp:Literal ID="ltrlGender" runat="server"></asp:Literal></p>
            </div>
            <div class="column">
                <asp:Label ID="lblAddress" runat="server"><b>Home Address</b></asp:Label>
                <p><asp:Literal ID="ltrlAddress" runat="server"></asp:Literal></p>
            </div>
        </div>
    </div>
    <div class="profileButton">
        <asp:Button ID="btnChangeProfile" runat="server" Text="Change Profile" OnClick="btnChangeProfile_Click"/>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"/>
    </div>
</asp:Content>
