using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Views.customer
{
    public partial class cart_page : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;
            Cart cart;

            if (Session["user"] == null && Request.Cookies["sessionCookie"] == null)
            {
                Response.Redirect("~/Views/login.aspx");
            }
            else if (Request.Cookies["sessionCookie"] != null)
            {
                var id = int.Parse(Request.Cookies["sessionCookie"].Value);
                customer = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();

                cart = (from x in db.Carts where x.CustomerID == id select x).FirstOrDefault();

                Session["user"] = customer;

                CartHandler cartHandler = new CartHandler();
                AlbumHandler albumHandler = new AlbumHandler();
                List<Cart> cartList = cartHandler.getCartFromId(id);

                if(cartList.Count != 0)
                {
                    List<Album> albumList = albumHandler.getAlbumFromId(cart.AlbumID);

                    rptrCart.DataSource = albumList;
                    rptrCart.DataBind();
                }
                else
                {
                    ltrlStatus.Text = "Cart is empty!";
                }
            }
        }

        protected void rptrCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var id = int.Parse(Request.Cookies["sessionCookie"].Value);
            Cart cart = (from x in db.Carts where x.CustomerID == id select x).FirstOrDefault();

            Album albumDB;
            albumDB = (from x in db.Albums where x.AlbumID == cart.AlbumID select x).FirstOrDefault();

            ((Literal)e.Item.FindControl("ltrlAlbumQty")).Text = cart.Qty.ToString();
            ((Literal)e.Item.FindControl("ltrlAlbumPrice")).Text = string.Format("{0, 15:N0}", albumDB.AlbumPrice);
        }

        protected void btnDeleteCart_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Request.Cookies["sessionCookie"].Value);

            CartController cartController = new CartController();
            cartController.deleteCart(id);

            Response.Redirect("home.aspx");
        }
    }
}