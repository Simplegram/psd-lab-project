<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="artist_detail.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.artist_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title" id="home">
        <h1>Artist Detail</h1>
        <div class="artist" id="card">
            <div class="artist" id="title">
                <h2><asp:Literal ID="ltrlArtistId" runat="server"></asp:Literal></h2>
                <h2><asp:Literal ID="ltrlArtistName" runat="server"></asp:Literal></h2>
            </div>
            <img id="artist_img"  runat="server"/>
        </div>
        <%foreach (var t in albums)
        {%>
        <div class="detail" id="artist">
            <div class="artist" id="albums">
                <h2>Albums</h2>
			    <div class="artist" id="card">
				    <div class="artist" id="title">
					    <h3><%=t.ArtistID %></h3>
					    <h3><%=t.AlbumName %></h3>
                        <h3>Price <asp:Literal ID="ltrlPrice" runat="server"></asp:Literal></h3>
				    </div>
                    <h3><%=t.AlbumDescription %></h3>
                    <h3><%=t.AlbumStock %> pcs available</h3>
				    <img id="albums_img" src="../../Images/albums/<%=t.AlbumImage%>"/>
			    </div>
            </div>
        </div>
        <div class="menu">
            <div class="menu-container">
                <a id="artist_update" href="artist_update.aspx?artistId=<%=t.ArtistID%>">Change Artist Detail</a>
                <a id="artist_delete" href="artist_delete.aspx?artistId=<%=t.ArtistID%>">Delete Artist</a>
            </div>
        </div>
        <%}%>
        <h3><asp:Literal ID="ltrlStatus" runat="server"></asp:Literal></h3>
    </div>
</asp:Content>
