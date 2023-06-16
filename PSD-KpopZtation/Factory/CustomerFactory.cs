using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Factory
{
    public class CustomerFactory
    {
        Database1Entities db = Database.getInstance();
        public static Customer create(int id, string name, string email, string gender, string address, string password)
        {
            Customer customer = new Customer();

            return customer;
        }
    }
}