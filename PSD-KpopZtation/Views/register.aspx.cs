using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation
{
    public partial class register : System.Web.UI.Page
    {
        Database1Entities db = Database.getDb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerName = tbxName.Text;
            customer.CustomerEmail = tbxEmail.Text;
            customer.CustomerPassword = tbxPassword.Text;
            customer.CustomerGender = rblGender.SelectedItem.Text;
            customer.CustomerAddress = tbxAddress.Text;
        }
    }
}