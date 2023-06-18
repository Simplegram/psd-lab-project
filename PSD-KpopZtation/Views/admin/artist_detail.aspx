<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="artist_detail.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.artist_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h1>Artist Detail</h1>
        <div class="artist" id="card">
            <div class="artist" id="title">
                <h2><asp:Literal ID="ltrlArtistId" runat="server"></asp:Literal></h2>
                <h2><asp:Literal ID="ltrlArtistName" runat="server"></asp:Literal></h2>
            </div>
            <img id="artist_img"  runat="server"/>
        </div>
        <div class="detail" id="artist">
            <div class="artist" id="albums">
                <h2>Albums</h2>
                <asp:Repeater ID="rptrAlbums" runat="server">
                    <ItemTemplate>
                        <div>
                            <a style="color: black; text-decoration:underline; font-size: 1rem" href="album_add.aspx?artistId=<%# DataBinder.Eval(Container.DataItem, "ArtistID") %>">Add Album</a>
                        </div>
                        <div class="album" id="card">
				            <div class="album" id="title">
                                <div style="font-size: 0.5rem; display: flex; justify-content: flex-start">
                                    <h3><%# DataBinder.Eval(Container.DataItem, "AlbumID")%></h3>
                                </div>
                                <div style="display: flex; flex-direction: row; justify-content: space-between">
                                    <h3 style="margin-top: 0"><%# DataBinder.Eval(Container.DataItem, "AlbumName")%></h3>
                                    <h3 style="margin-top: 0">Rp<%# string.Format("{0, 15:N0}", DataBinder.Eval(Container.DataItem, "AlbumPrice").ToString())%></h3>
                                </div>
				            </div>
                            <div style="display: flex; justify-content: flex-start">
                                <h3 style="margin-top: 0"><%# DataBinder.Eval(Container.DataItem, "AlbumStock")%> pcs available</h3>
                            </div>
				            <img src="../../Images/albums/<%# DataBinder.Eval(Container.DataItem, "AlbumImage")%>" style="width: 512px"/>
                            <h3 id="albumDescription" style="margin: 5%;"><%# DataBinder.Eval(Container.DataItem, "AlbumDescription")%></h3>
                            <div style="width: 100%; display: flex; flex-direction: row; justify-content: space-between; padding: 0 5% 5% 5%">
                                <a href="album_update.aspx?albumId=<%# DataBinder.Eval(Container.DataItem, "AlbumID") %>&artistId=<%# DataBinder.Eval(Container.DataItem, "ArtistID") %>">Update Album</a>
                                <a href="album_delete.aspx?albumId=<%# DataBinder.Eval(Container.DataItem, "AlbumID") %>&artistId=<%# DataBinder.Eval(Container.DataItem, "ArtistID") %>">Delete Album</a>
                            </div>
			            </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <h3><asp:Literal ID="ltrlStatus" runat="server"></asp:Literal></h3>
    </div>
</asp:Content>
