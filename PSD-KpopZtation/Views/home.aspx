<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Unauthorized.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PSD_KpopZtation.Views.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title" id="home">
        <h1>Welcome to KpopZstation</h1>
        <h2>Our Artists</h2>
    </div>
	<div class="artists">
		<div class="artists">
			<asp:Repeater ID="rptrArtist" runat="server">
				<ItemTemplate>
					<div class="artists">
						<div class="artist" id="card">
							<div class="artist" id="title">
								<h3><%# DataBinder.Eval(Container.DataItem, "ArtistID")%></h3>
								<h3><%# DataBinder.Eval(Container.DataItem, "ArtistName")%></h3>
							</div>
							<img src="../../Images/artists/<%# DataBinder.Eval(Container.DataItem, "ArtistImage")%>"/>
							<a href="artist_detail.aspx?artistId=<%# DataBinder.Eval(Container.DataItem, "ArtistID")%>">View Artist</a>
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</div>
</asp:Content>
