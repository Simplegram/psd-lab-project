using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Handlers
{
    public class CartHandler
    {
        CartRepository cartRepo;

        public CartHandler()
        {
            cartRepo = new CartRepository();
        }
        public void addToCart(int custId, int albumId, int qty)
        {
            cartRepo.addToCart(custId, albumId, qty);
        }
        
        public List<Cart> getCartFromId(int custId)
        {
            return cartRepo.getAlbumFromId(custId);
        }

        public void deleteCart(int custId)
        {
            cartRepo.deleteCart(custId);
        }
    }
}