using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Views.admin
{
    public partial class album_add : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;
            Artist artist;

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

            string artistId = Request.QueryString["artistId"];

            artist = (from x in db.Artists where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();

            ltrlArtistName.Text = artist.ArtistName;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}