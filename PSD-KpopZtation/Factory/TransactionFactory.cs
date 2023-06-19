using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Factory
{
    public class TransactionFactory
    {
        public static TransactionDetail createTransactionDetail(int albumId, int albumQty)
        {
            TransactionDetail transactionDetail = new TransactionDetail();

            transactionDetail.AlbumID = albumId;
            transactionDetail.Qty = albumQty;

            return transactionDetail;
        }

        public static TransactionHeader createTransactionHeader(DateTime date, int custId)
        {
            TransactionHeader transactionHeader = new TransactionHeader();

            transactionHeader.TransactionDate = date;
            transactionHeader.CustomerID = custId;

            return transactionHeader;
        }
    }
}