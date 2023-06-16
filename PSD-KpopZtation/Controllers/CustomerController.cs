﻿using System;
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
        public static string validate(string name, string email, string gender, string address, string password)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                return "Fill-in all the data columns!";
            }

            if(name.Length < 5 || name.Length > 50)
            {
                return "Name must be at least 5 and at most 50 characters long!";
            } 
            if(CustomerRepository.getEmail(email) != null)
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
            return "Success!";
        }
    }
}