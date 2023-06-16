using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;

namespace PSD_KpopZtation
{
    public partial class register : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = tbxName.Text;
            string email = tbxEmail.Text;
            string gender = rblGender.SelectedItem.Text;
            string address = tbxAddress.Text;
            string password = tbxPassword.Text;

            lblStatus.Text = CustomerController.validate(name, email, gender, address, password);
        }
    }
}