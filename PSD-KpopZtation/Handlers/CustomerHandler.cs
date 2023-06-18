using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Handlers
{
    public class CustomerHandler
    {
        CustomerRepository customerRepo;
        public CustomerHandler()
        {
            customerRepo = new CustomerRepository();
        }
        
        public void updateProfile(string name, string email, string gender, string address, string password, int custId)
        {
            customerRepo.updateCustomer(name, email, gender, address, password, custId);
        }
    }
}