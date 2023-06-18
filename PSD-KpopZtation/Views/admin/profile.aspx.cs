using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Views.admin
{
    public partial class profile : System.Web.UI.Page
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

                    ltrlNamaUser.Text = customer.CustomerName;
                    ltrlEmail.Text = customer.CustomerEmail;
                    ltrlGender.Text = customer.CustomerGender;
                    ltrlAddress.Text = customer.CustomerAddress;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddSeconds(-1);
            }

            Session.Remove("user");
            Response.Redirect("../home.aspx");
        }

        protected void btnChangeProfile_Click(object sender, EventArgs e)
        {
            Customer customer;
            var id = int.Parse(Request.Cookies["sessionCookie"].Value);
            customer = (from x in db.Customers where x.CustomerID == id select x).FirstOrDefault();

            Response.Redirect("profile_update.aspx?userId=" + customer.CustomerID);
        }
    }
}