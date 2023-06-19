<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Customer.Master" AutoEventWireup="true" CodeBehind="transaction_history.aspx.cs" Inherits="PSD_KpopZtation.Views.customer.transaction_history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h1 style="margin-bottom: 0">Transaction History</h1>
        <div class="page">
            <div class="page-content">
                <asp:Repeater runat="server" ID="rptrTransaction" OnItemDataBound="rptrTransaction_ItemDataBound">
                    <ItemTemplate>
                        <div class="transaction-strip">
                            <div style="display: flex; flex-direction: column" class="strip-content">
                                <div class="id-date-name">
                                    <h3>ID: <%# DataBinder.Eval(Container.DataItem, "TransactionID")%></h3>
                                    <h3>Date: <asp:Literal ID="ltrlDate" runat="server"></asp:Literal></h3>
                                    <h3>Name: <asp:Literal ID="ltrlCustomerName" runat="server"></asp:Literal></h3>
                                </div>
                                <asp:Repeater ID="rptrAlbum" runat="server" OnItemDataBound="rptrAlbum_ItemDataBound">
                                    <ItemTemplate>
                                        <div style="display: flex; flex-direction: row" class="album-info">
                                            <img src="../../Images/albums/<%# DataBinder.Eval(Container.DataItem, "AlbumImage")%>" style="width: 100px; object-fit: none;"/>
                                            <div class="name-qty-price">
                                                <h3><%# DataBinder.Eval(Container.DataItem, "AlbumName")%></h3>
                                                <h3><asp:Literal ID="ltrlAlbumQty" runat="server"></asp:Literal></h3>
                                                <h3><%# DataBinder.Eval(Container.DataItem, "AlbumPrice")%></h3>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <asp:Literal ID="ltrlStatus" runat="server"></asp:Literal>
    </div>
</asp:Content>
