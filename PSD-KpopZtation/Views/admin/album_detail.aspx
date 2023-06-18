<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="album_detail.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.album_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h1 style="margin-bottom: 0">Album Detail</h1>
        <div class="album" id="card">
            <div class="album" id="title">
                <div style="font-size: 0.5rem; display: flex; justify-content: flex-start">
                    <h3><asp:Literal ID="ltrlAlbumId" runat="server"></asp:Literal></h3>
                </div>
                <div style="display: flex; flex-direction: row; justify-content: space-between">
                    <h3 style="margin-top: 0"><asp:Literal ID="ltrlAlbumName" runat="server"></asp:Literal></h3>
                    <h3 style="margin-top: 0">Rp<asp:Literal ID="ltrlAlbumPrice" runat="server"></asp:Literal></h3>
                </div>
            </div>
            <div style="display: flex; justify-content: flex-start">
                <h3 style="margin-top: 0"><asp:Literal ID="ltrlAlbumStock" runat="server"></asp:Literal> pcs available</h3>
            </div>
			<img id="album_img" style="width: 512px" runat="server"/>
            <h3 id="albumDescription" style="margin: 5%;"><asp:Literal ID="ltrlAlbumDesc" runat="server"></asp:Literal></h3>
        </div>
    </div>
</asp:Content>
