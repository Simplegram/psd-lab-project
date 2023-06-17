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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptrArtist.DataSource = db.Artists.ToList();
                rptrArtist.DataBind();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

        }
    }
}