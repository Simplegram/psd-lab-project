using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Repositories
{
    public class CustomerRepository
    {
        private static Database1Entities db = Database.getInstance();

        public static string getEmail(string email)
        {
            try
            {
                return (from x in db.Customers where x.CustomerEmail == email select x).FirstOrDefault().ToString();
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }
    }
}