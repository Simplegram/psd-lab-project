using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;

namespace PSD_KpopZtation.Views.customer
{
    public partial class transaction_history_add : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;

            if (Session["user"] == null && Request.Cookies["sessionCookie"] == null)
            {
                Response.Redirect("~/Views/login.aspx");
            }
            else if (Request.Cookies["sessionCookie"] != null)
            {
                var id = int.Parse(Request.Cookies["sessionCookie"].Value);

                customer = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();

                Session["user"] = customer;

                string albumId = Request.QueryString["albumId"];

                Cart cart = (from x in db.Carts where x.AlbumID.ToString().Equals(albumId) select x).FirstOrDefault();

                int custId = id;
                int albumQty = cart.Qty;

                transactionController.addTransaction(custId, albumQty, int.Parse(albumId));

                CartController cartController = new CartController();
                cartController.deleteCart(id);

                Response.Redirect("home.aspx");
            }
        }
    }
}