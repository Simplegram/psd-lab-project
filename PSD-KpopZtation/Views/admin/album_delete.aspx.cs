using System;
using System.IO;
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
    public partial class album_delete : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();

        AlbumController albumController = new AlbumController();
        Album album = new Album();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;
            if (!IsPostBack)
            {
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
                string albumImage = Request.QueryString["albumImage"];
                string artistId = Request.QueryString["artistId"];

                string path = Server.MapPath(@"../../Images/albums/" + albumImage);
                File.Delete(path);

                album = albumController.getAlbum(int.Parse(albumId));
                albumController.deleteAlbum(int.Parse(albumId));

                Response.Redirect("artist_detail.aspx?artistId=" + artistId);
            }
        }
    }
}