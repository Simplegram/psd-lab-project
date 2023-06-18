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
        public static Customer createCustomer(string name, string email, string gender, string address, string password)
        {
            Customer customer = new Customer();

            customer.CustomerID = CustomerRepository.getLastID() + 1;
            customer.CustomerName = name;
            customer.CustomerEmail = email;
            customer.CustomerGender = gender;
            customer.CustomerAddress = address;
            customer.CustomerPassword = password;
            customer.CustomerRole = "Cust";

            return customer;
        }
    }
}