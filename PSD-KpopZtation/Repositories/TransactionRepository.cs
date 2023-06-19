using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;
using PSD_KpopZtation.Factory;

namespace PSD_KpopZtation.Repositories
{
    public class TransactionRepository
    {
        public static Database1Entities db = Database.getInstance();
        public void addTransaction(int custId, int albumQty, int albumId)
        {
            TransactionDetail transactionDetail = TransactionFactory.createTransactionDetail(albumId, albumQty);
            transactionDetail.TransactionID = getLastDetailId() + 1;

            DateTime date = DateTime.Today;
            TransactionHeader transactionHeader = TransactionFactory.createTransactionHeader(date, custId);
            transactionHeader.TransactionID = getLastHeaderId() + 1;

            db.TransactionDetails.Add(transactionDetail);
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }

        public int getLastDetailId()
        {
            int id = (from x in db.TransactionDetails select x.TransactionID).ToList().LastOrDefault();
            if (id == 0)
            {
                return 0;
            }
            else
            {
                return id;
            }
        }

        public int getLastHeaderId()
        {
            int id = (from x in db.TransactionHeaders select x.TransactionID).ToList().LastOrDefault();
            if (id == 0)
            {
                return 0;
            }
            else
            {
                return id;
            }
        }

        public List<TransactionHeader> getHeaderListFromId(int custId)
        {
            return (from header in db.TransactionHeaders where header.CustomerID == custId select header).ToList();
        }

        public TransactionHeader getHeaderFromId(int custId)
        {
            return (from header in db.TransactionHeaders where header.CustomerID == custId select header).FirstOrDefault();

        }

        public List<TransactionDetail> getTransListFromId(int transId)
        {
            return (from trans in db.TransactionDetails where trans.TransactionID == transId select trans).ToList();
        }

        public TransactionDetail getTransFromId(int transId)
        {
            return (from trans in db.TransactionDetails where trans.TransactionID == transId select trans).FirstOrDefault();
        }
    }
}