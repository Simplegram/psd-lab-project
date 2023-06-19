using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Controllers;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Controllers
{
    public class TransactionController
    {
        public TransactionHandler transactionHandler;
        public TransactionController()
        {
            transactionHandler = new TransactionHandler();
        }

        public void addTransaction(int custId, int albumQty, int albumId)
        {
            transactionHandler.addTransaction(custId, albumQty, albumId);
        }
    }
}