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
    public partial class login : System.Web.UI.Page
    {
        Database1Entities db = Database.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer;
            if (!IsPostBack)
            {
                if (Request.Cookies["sessionCookie"] != null)
                {
                    var id = int.Parse(Request.Cookies["sessionCookie"].Value);

                    customer = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();

                    Session["user"] = customer;

                    if (customer.CustomerID == 1)
                    {
                        Response.Redirect("~/Views/admin/home.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Views/customer/home.aspx");
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbxEmail.Text;
            string password = tbxPassword.Text;

            lblStatus.Text = CustomerController.validateLogin(email, password);

            if (lblStatus.Text.Equals("Login Success"))
            {
                Customer customer;
                customer = CustomerRepository.getCustomer(email);

                HttpCookie sessionCookie = new HttpCookie("sessionCookie");
                Session["user"] = customer;

                if(cbxRemember.Checked == true)
                { 
                    sessionCookie.Value = customer.CustomerID.ToString();
                    sessionCookie.Expires = DateTime.Now.AddDays(30);

                    Response.Cookies.Add(sessionCookie);
                }

                sessionCookie.Value = customer.CustomerID.ToString();
                Response.Cookies.Add(sessionCookie);
                if(customer.CustomerID == 1)
                {
                    Response.Redirect("~/Views/admin/home.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/customer/home.aspx");
                }
            }
        }
    }
}