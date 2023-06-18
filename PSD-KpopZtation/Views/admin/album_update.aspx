<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="album_update.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.update_album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="margin-bottom: 0">Updating album<h3 style="margin: 0; font-weight: 400"><asp:Literal ID="ltrlAlbumName" runat="server"></asp:Literal></h3></h2>
    <h2 style="margin-top: 0; margin-bottom: 0">From artist<h3 style="margin: 0 0 2.5% 0; font-weight: 400"><asp:Literal ID="ltrlArtistName" runat="server"></asp:Literal></h3></h2>
    <div style="display: flex; flex-direction: column; align-items: center">
        <div class="column">
            <asp:Label ID="lblAlbumName" runat="server"><b>Album Name</b></asp:Label>
            <asp:TextBox ID="tbxAlbumName" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblAlbumDesc" runat="server"><b>Album Desc</b></asp:Label>
            <asp:TextBox ID="tbxAlbumDesc" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblAlbumPrice" runat="server"><b>Album Price</b></asp:Label>
            <asp:TextBox ID="tbxAlbumPrice" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblAlbumStock" runat="server"><b>Album Stock</b></asp:Label>
            <asp:TextBox ID="tbxAlbumStock" runat="server"></asp:TextBox>
        </div>
        <div class="column">
            <asp:Label ID="lblAlbumImage" runat="server"><b>Album Image</b></asp:Label>
            <img id="albumImage" runat="server" style="width: 250px;" src=""/>
            <asp:FileUpload ID="flAlbumImage" runat="server"/>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update/Change Data" OnClick="btnUpdate_Click"/>
        <asp:Literal ID="ltrlStatus" runat="server"></asp:Literal>
    </div>
</asp:Content>
