using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Factory;

namespace PSD_KpopZtation.Repositories
{
    public class CartRepository
    {
        private static Database1Entities db = new Database1Entities();

        public void addToCart(int custId, int albumId, int qty)
        {
            Cart cart = CartFactory.createCart(custId, albumId, qty);

            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public List<Cart> getAlbumFromId(int custId)
        {
            return (from cart in db.Carts where cart.CustomerID == custId select cart).ToList();
        }

        public Cart getCart(int custId)
        {
            return (from x in db.Carts where  x.CustomerID == custId select x).FirstOrDefault();
        }

        public void deleteCart(int custId)
        {
            Cart cart = getCart(custId);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
    }
}