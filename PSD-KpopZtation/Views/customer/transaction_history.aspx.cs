using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Views.customer
{
    public partial class transaction_history : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        TransactionHandler transactionHandler = new TransactionHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;
            TransactionDetail transactionDetail;
            TransactionHeader transactionHeader;

            if (Session["user"] == null && Request.Cookies["sessionCookie"] == null)
            {
                Response.Redirect("~/Views/login.aspx");
            }
            else if (Request.Cookies["sessionCookie"] != null)
            {
                var id = int.Parse(Request.Cookies["sessionCookie"].Value);
                customer = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();

                Session["user"] = customer;

                transactionHeader = transactionHandler.getHeaderFromId(id);
                transactionDetail = transactionHandler.getDetailFromId(transactionHeader.TransactionID);

                List<TransactionHeader> transactionHeaders = transactionHandler.getHeaderListFromId(id);
                List<TransactionDetail> transactionDetails = transactionHandler.getTransListFromId(transactionHeader.TransactionID);

                if(transactionHeaders.Count != 0)
                {
                    rptrTransaction.DataSource = transactionDetails;
                    rptrTransaction.DataBind();
                }
                else
                {
                    ltrlStatus.Text = "No transaction exists";
                }
            }
        }

        protected void rptrTransaction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var id = int.Parse(Request.Cookies["sessionCookie"].Value);

            TransactionHeader transactionHeader = transactionHandler.getHeaderFromId(id);
            TransactionDetail transactionDetail = transactionHandler.getDetailFromId(transactionHeader.TransactionID);
            Customer customer = (from x in db.Customers where x.CustomerID == transactionHeader.CustomerID select x).FirstOrDefault();
            List<Album> album = (from x in db.Albums where x.AlbumID == transactionDetail.AlbumID select x).ToList();

            Repeater repeater = (Repeater)e.Item.FindControl("rptrAlbum");
            repeater.DataSource = album;
            repeater.DataBind();

            ((Literal)e.Item.FindControl("ltrlCustomerName")).Text = customer.CustomerName;
            ((Literal)e.Item.FindControl("ltrlDate")).Text = transactionHeader.TransactionDate.ToString();
        }

        protected void rptrAlbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var id = int.Parse(Request.Cookies["sessionCookie"].Value);
            TransactionHeader transactionHeader = transactionHandler.getHeaderFromId(id);
            TransactionDetail transactionDetail = transactionHandler.getDetailFromId(transactionHeader.TransactionID);
            ((Literal)e.Item.FindControl("ltrlAlbumQty")).Text = transactionDetail.Qty.ToString();
        }
    }
}