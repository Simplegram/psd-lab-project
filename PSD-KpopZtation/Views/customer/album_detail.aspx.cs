using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;


namespace PSD_KpopZtation.Views.customer
{
    public partial class album_detail : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        Album album = new Album();
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

                string albumId = Request.QueryString["albumId"];

                album = (from x in db.Albums where x.AlbumID.ToString().Equals(albumId) select x).FirstOrDefault();
                album_img.Src = "../../Images/albums/" + album.AlbumImage;

                ltrlAlbumId.Text = albumId;
                ltrlAlbumName.Text = album.AlbumName;
                ltrlAlbumPrice.Text = string.Format("{0, 15:N0}", album.AlbumPrice);
                ltrlAlbumStock.Text = album.AlbumStock.ToString();
                ltrlAlbumDesc.Text = album.AlbumDescription;
            }
        }
    }
}