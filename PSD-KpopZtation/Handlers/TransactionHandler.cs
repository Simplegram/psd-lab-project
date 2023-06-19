using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Handlers
{
    public class TransactionHandler
    {
        TransactionRepository transactionRepo;
        public TransactionHandler()
        {
            transactionRepo = new TransactionRepository();
        }

        public void addTransaction(int custId, int albumQty, int albumId)
        {
            transactionRepo.addTransaction(custId, albumQty, albumId);
        }

        public List<TransactionHeader> getHeaderListFromId(int custId)
        {
            return transactionRepo.getHeaderListFromId(custId);
        }

        public TransactionHeader getHeaderFromId(int custId)
        {
            return transactionRepo.getHeaderFromId(custId);
        }

        public List<TransactionDetail> getTransListFromId(int transId)
        {
            return transactionRepo.getTransListFromId(transId);
        }

        public TransactionDetail getDetailFromId(int transId)
        {
            return transactionRepo.getTransFromId(transId);
        }
    }
}