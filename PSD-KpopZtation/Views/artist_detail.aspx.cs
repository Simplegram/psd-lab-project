using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Views
{
    public partial class artist_detail : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        Artist artist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string artistId = Request.QueryString["artistId"];

                if (artistId != null)
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

        protected void rptrAlbums_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Album albumDB;
            string artistId = Request.QueryString["artistId"];
            albumDB = (from x in db.Albums where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();
            ((Literal)e.Item.FindControl("ltrlAlbumPrice")).Text = string.Format("{0, 15:N0}", albumDB.AlbumPrice);
        }
    }
}