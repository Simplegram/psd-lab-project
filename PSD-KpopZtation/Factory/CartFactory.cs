using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int custId, int albumId, int qty)
        {
            Cart cart = new Cart();

            cart.CustomerID = custId;
            cart.AlbumID = albumId;
            cart.Qty = qty;

            return cart;
        }
    }
}