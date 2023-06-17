using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;

namespace PSD_KpopZtation.Views.admin
{
    public partial class home : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                }

                rptrArtist.DataSource = db.Artists.ToList();
                rptrArtist.DataBind();
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddSeconds(-1);
            }

            Session.Remove("User");
            Response.Redirect("~/Views/home.aspx");
        }
    }
}