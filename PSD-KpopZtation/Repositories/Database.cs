using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Repositories
{
    public class Database
    {
        private static Database1Entities db = null;

        public static Database1Entities getInstance()
        {
            if(db == null)
            {
                db = new Database1Entities();
            }
            return db;
        }
    }
}