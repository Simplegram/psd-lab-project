<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Customer.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PSD_KpopZtation.Views.customer.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title" id="home">
        <h1>Welcome to KpopZstation, <asp:Literal ID="ltrlName" runat="server"></asp:Literal></h1>
        <h2>Our Artists</h2>
    </div>
    <div class="artists">
		<%foreach (var t in artists) 
		{%>
			<div class="artist" id="card">
				<div class="artist" id="title">
					<h3><%=t.ArtistID %></h3>
					<h3><%=t.ArtistName %></h3>
				</div>
				<img src="../../Images/artists/<%=t.ArtistImage%>"/>
			</div>
		<%}%>
	</div>
</asp:Content>
