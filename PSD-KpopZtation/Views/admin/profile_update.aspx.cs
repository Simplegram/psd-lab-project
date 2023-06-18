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
    public partial class profile_update : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer customer;

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

                string userId = Request.QueryString["userId"];

                customer = (from x in db.Customers where x.CustomerID.ToString().EndsWith(userId) select x).FirstOrDefault();

                tbxCustomerName.Text = customer.CustomerName;
                tbxCustomerEmail.Text = customer.CustomerEmail;
                rblCustomerGender.SelectedValue = customer.CustomerGender;
                tbxCustomerAddress.Text = customer.CustomerAddress;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userId = Request.QueryString["userId"];

            string name = tbxCustomerName.Text;
            string email = tbxCustomerEmail.Text;
            string gender = rblCustomerGender.SelectedItem.Text;
            string address = tbxCustomerAddress.Text;
            string password = tbxCustomerPass.Text;

            ltrlStatus.Text = CustomerController.validateProfileChange(name, email, gender, address, password, int.Parse(userId));

            if (ltrlStatus.Text.Equals("Success!"))
            {
                Response.Redirect("profile.aspx");
            }
        }
    }
}