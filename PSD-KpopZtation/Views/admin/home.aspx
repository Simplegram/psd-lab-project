<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Admin.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PSD_KpopZtation.Views.admin.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="title" id="home">
        <h1>Welcome to KpopZstation Admin</h1>
        <h2 style="margin-bottom: 0">Artists</h2>
    </div>
	<div class="artists">
		<asp:Repeater ID="rptrArtist" runat="server">
			<ItemTemplate>
				<div class="artist" id="card">
					<div class="artist" id="title">
						<h3><%# DataBinder.Eval(Container.DataItem, "ArtistID")%></h3>
						<h3><%# DataBinder.Eval(Container.DataItem, "ArtistName")%></h3>
					</div>
					<img src="../../Images/artists/<%# DataBinder.Eval(Container.DataItem, "ArtistImage")%>"/>
					<a href="artist_detail.aspx?artistId=<%# DataBinder.Eval(Container.DataItem, "ArtistID")%>">View Artist</a>
				</div>
			</ItemTemplate>
        </asp:Repeater>
	</div>
</asp:Content>
