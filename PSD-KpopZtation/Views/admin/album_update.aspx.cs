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
    public partial class update_album : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        AlbumController albumController = new AlbumController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer customer;
                Album album;
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
                string albumId = Request.QueryString["albumId"];

                album = (from x in db.Albums where x.ArtistID.ToString().Equals(artistId) && x.AlbumID.ToString().Equals(albumId) select x).FirstOrDefault();
                artist = (from x in db.Artists where x.ArtistID.ToString().Equals(artistId) select x).FirstOrDefault();

                tbxAlbumName.Text = album.AlbumName;
                tbxAlbumDesc.Text = album.AlbumDescription;
                tbxAlbumPrice.Text = album.AlbumPrice.ToString();
                tbxAlbumStock.Text = album.AlbumStock.ToString();
                var image = album.AlbumImage;
                albumImage.Src = "../../Images/albums/" + image;

                ltrlAlbumName.Text = album.AlbumName;
                ltrlArtistName.Text = artist.ArtistName;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] extension = { ".png", ".jpg", ".jpeg", ".jfif" };

            string artistId = Request.QueryString["artistId"];
            string albumId = Request.QueryString["albumId"];

            string name = tbxAlbumName.Text;
            string desc = tbxAlbumDesc.Text;
            int price;
            int stock;
            int imageSize;
            string imagePath = System.IO.Path.GetExtension(flAlbumImage.FileName);

            try
            {
                price = int.Parse(tbxAlbumPrice.Text);
                stock = int.Parse(tbxAlbumStock.Text);
                imageSize = flAlbumImage.PostedFile.ContentLength;
            }
            catch (FormatException s)
            {
                ltrlStatus.Text = "Field can\'t be null or empty!";
                return;
            }

            if (flAlbumImage.HasFile)
            {
                const int maxImageSize = 2000 * 1024;

                if (imageSize > maxImageSize)
                {
                    ltrlStatus.Text = "Image file must be lower than 2MB!";
                    return;
                } else if (!(extension.Contains(imagePath)))
                {
                    ltrlStatus.Text = "File can only be in .png, .jpg, .jpeg, and .jfif format!";
                    return;
                }
            }

            ltrlStatus.Text = albumController.validateAlbumChange(name, desc, price, stock, int.Parse(albumId));

            if (ltrlStatus.Text.Equals("Success!"))
            {
                Response.Redirect("artist_detail.aspx?artistId="+artistId);
            }
        }
    }
}