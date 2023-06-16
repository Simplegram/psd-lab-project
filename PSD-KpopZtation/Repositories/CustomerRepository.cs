using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Repositories
{
    public class CustomerRepository
    {
        Database1Entities db = Database.getInstance();

        public static string getEmail(string email)
        {
            return (from x in db.Customers where x.CustomerEmail == email select x).FirstOrDefault();
        }
    }
}