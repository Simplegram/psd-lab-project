using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Factory;

namespace PSD_KpopZtation.Repositories
{
    public class CustomerRepository
    {
        private static Database1Entities db = Database.getInstance();

        public void addCustomer(string name, string email, string gender, string address, string password)
        {
            Customer customer = CustomerFactory.createCustomer(name, email, gender, address, password);

            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static string getEmail(string email)
        {
            try
            {
                return (from x in db.Customers where x.CustomerEmail.Equals(email) select x.CustomerEmail).ToList().LastOrDefault().ToString();
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }

        public static int getLastID()
        {
            int id = (from x in db.Customers select x.CustomerID).ToList().LastOrDefault();
            return id;
        }
    }
}