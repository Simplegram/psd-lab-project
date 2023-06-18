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
    public partial class album_add : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        AlbumController albumController = new AlbumController();
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
            string[] extension = { ".png", ".jpg", ".jpeg", ".jfif" };
            string artistId = Request.QueryString["artistId"];

            string name = tbxAlbumName.Text;
            string desc = tbxAlbumDesc.Text;
            int price;
            int stock;
            int imageSize;
            string image = flAlbumImage.FileName;
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
                }
                else if (!(extension.Contains(imagePath)))
                {
                    ltrlStatus.Text = "File can only be in .png, .jpg, .jpeg, and .jfif format!";
                    return;
                }
            }
            else if (!flAlbumImage.HasFile)
            {
                ltrlStatus.Text = "Must upload an image!";
                return;
            }

            ltrlStatus.Text = albumController.validateAlbum(name, desc, price, stock, image, int.Parse(artistId));

            if (ltrlStatus.Equals("Success!"))
            {
                string savePath = "../../Images/albums/";
                flAlbumImage.PostedFile.SaveAs(savePath);
                Response.Redirect("artist_detail.aspx?artistId=" + artistId);
            }
        }
    }
}