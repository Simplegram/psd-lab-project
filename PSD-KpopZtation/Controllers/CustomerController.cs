using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Controllers
{
    public class CustomerController
    {
        private static CustomerRepository custRepo = new CustomerRepository();
        private static CustomerHandler custHandler = new CustomerHandler();

        public static string validateRegister(string name, string email, string gender, string address, string password)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                return "Fill-in all the data columns!";
            }

            if(name.Length < 5 || name.Length > 50)
            {
                return "Name must be at least 5 and at most 50 characters long!";
            } 
            if(!string.IsNullOrEmpty(CustomerRepository.getEmail(email)))
            {
                return "Email already exist in the system!";
            } 
            if(gender == "null")
            {
                return "Gender must be selected!";
            } 
            if(!address.EndsWith("Street"))
            {
                return "Address must end with \'Street\'";
            }
            if (!(password.All(char.IsLetterOrDigit)))
            {
                return "Password must be alphanumeric!";
            }

            custRepo.addCustomer(name, email, gender, address, password);

            return "Success!";
        }

        public static string validateLogin(string email, string password)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Fill-in all the credential columns!";
            }

            string realPass = CustomerRepository.getPass(email);
            if (realPass.Equals("null"))
            {
                return "User not found! Register an account first.";
            }

            if (password.Equals(realPass))
            {
                return "Login Success";
            }
            else if (!password.Equals(realPass))
            {
                return "Wrong Password!";
            }
            return "User not found! Register an account first.";
        }

        public static string validateProfileChange(string name, string email, string gender, string address, string password, int custId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                return "Fill-in all the data columns!";
            }

            if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be at least 5 and at most 50 characters long!";
            }
            if (!(CustomerRepository.getSpecificEmail(custId).Equals(email)))
            {
                if (!string.IsNullOrEmpty(CustomerRepository.getEmail(email)))
                {
                    return "Email already exist in the system!";
                }
            }
            if (gender == "null")
            {
                return "Gender must be selected!";
            }
            if (!address.EndsWith("Street"))
            {
                return "Address must end with \'Street\'";
            }
            if (!(password.All(char.IsLetterOrDigit)))
            {
                return "Password must be alphanumeric!";
            }

            custHandler.updateProfile(name, email, gender, address, password, custId);

            return "Success!";
        }
    }
}