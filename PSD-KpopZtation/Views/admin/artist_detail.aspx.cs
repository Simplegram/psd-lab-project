using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Views.admin
{
    public partial class artist_detail : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                if(artistId != null) 
                {
                    artist = (from x in db.Artists where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();
                    artist_img.Src = "../../Images/artists/" + artist.ArtistImage;

                    ltrlArtistId.Text = artist.ArtistID.ToString();
                    ltrlArtistName.Text = artist.ArtistName;

                    AlbumHandler albumHandler = new AlbumHandler();
                    List<Album> album = albumHandler.getArtistAlbums(artistId);

                    if (album.Count != 0)
                    {
                        rptrAlbums.DataSource = album;
                        rptrAlbums.DataBind();
                    }
                    else
                    {
                        ltrlStatus.Text = artist.ArtistName + " haven't released any albums yet.";
                    }
                }
            }
        }

        protected void btnAddAlbum_Click(object sender, EventArgs e)
        {
            string artistId = Request.QueryString["artistId"];
            Response.Redirect("album_add.aspx?artistId=" + artistId);
        }
    }
}