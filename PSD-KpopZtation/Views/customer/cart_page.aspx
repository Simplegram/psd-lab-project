<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Customer.Master" AutoEventWireup="true" CodeBehind="cart_page.aspx.cs" Inherits="PSD_KpopZtation.Views.customer.cart_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0; display: flex; flex-direction: column; align-items: center;">
        <h1 style="margin-bottom: 0">Your Cart</h1>
        <div class="page" style="width: 100vw; display: flex; flex-direction: column; align-items: center;">
            <div class="page-content" style="width: 90%; height: 80vh; display: flex; flex-direction: column; align-items: center; justify-content: space-evenly">
                <asp:Repeater ID="rptrCart" runat="server" OnItemDataBound="rptrCart_ItemDataBound">
                    <ItemTemplate>
                        <div class="cart-strip" style="width: 100%; height: 100px; display: flex; flex-direction: row; justify-content: center; background-color: dimgray; border-radius: 10px; overflow: hidden">
                            <img src="../../Images/albums/<%# DataBinder.Eval(Container.DataItem, "AlbumImage")%>" style="width: 100px; object-fit: none;"/>
                            <div class="name-qty" style="flex: 1; display: flex; flex-direction: column;">
                                <h3 style="justify-items: flex-start; margin-bottom: 0">Album Name: <%# DataBinder.Eval(Container.DataItem, "AlbumName")%></h3>
                                <h3 style="justify-items: flex-start; margin-top: 0">Quantity: <asp:Literal ID="ltrlAlbumQty" runat="server"></asp:Literal></h3>
                            </div>
                            <h3 runat="server">Rp<asp:Literal ID="ltrlAlbumPrice" runat="server"></asp:Literal></h3>
                        </div>
                        <a style="color: black" href="transaction_history_add.aspx?albumId=<%# DataBinder.Eval(Container.DataItem, "AlbumID")%>">Checkout</a>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="ltrlStatus" runat="server"></asp:Literal>
            </div>
            <asp:Button ID="btnDeleteCart" runat="server" Text="Clear Cart" OnClick="btnDeleteCart_Click"/>
        </div>
    </div>
</asp:Content>
