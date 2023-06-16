using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Controllers
{
    public class CustomerController
    {
        Database1Entities db = Database.getInstance();
        public string validate(string name, string email, string gender, string address, string password)
        {
            if(name.Length < 5 && name.Length > 50)
            {
                return "Name must be at least 5 and at most 50 characters long!";
            } else if(email == CustomerRepository.getEmail(email))
            {
                return "Email already exist in the system!";
            }
            return "Success!";
        }
    }
}