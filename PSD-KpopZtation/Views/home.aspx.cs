using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;

namespace PSD_KpopZtation.Views
{
    public partial class home : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        public List<Artist> artists = new List<Artist>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArtistController artistCtrl = new ArtistController();
                artists = artistCtrl.getAllArtist();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            
        }
    }
}