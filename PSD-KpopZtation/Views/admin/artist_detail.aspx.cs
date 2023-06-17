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
    public partial class artist_detail : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        public List<Album> albums = new List<Album>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer customer;
                Artist artist;
                Album album;

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

                if(artistId != null)
                {
                    artist = (from x in db.Artists where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();
                    artist_img.Src = "../../Images/artists/" + artist.ArtistImage;
                    artist_img.Width = 512;
                    artist_img.Height = 512;

                    ltrlArtistId.Text = artist.ArtistID.ToString();
                    ltrlArtistName.Text = artist.ArtistName;
                    try
                    {
                        album = (from x in db.Albums where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();

                        AlbumController albumCtrl = new AlbumController();
                        albums = albumCtrl.getArtistAlbums(artistId);

                        ltrlPrice.Text = string.Format("{0, 15:N0}", album.AlbumPrice);
                    } catch(NullReferenceException s)
                    {
                        ltrlStatus.Text = artist.ArtistName + " haven't released any albums yet.";
                    }
                }
            }
        }
    }
}