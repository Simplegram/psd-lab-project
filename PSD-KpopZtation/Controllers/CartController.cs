using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Handlers;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Controllers
{

    public class CartController
    {
        public CartHandler cartHandler;
        public CartController()
        {
            cartHandler = new CartHandler();
        }
        public string validateCart(int custId, int albumId, string qty)
        {
            if(string.IsNullOrEmpty(custId.ToString()) || string.IsNullOrEmpty(albumId.ToString()) || string.IsNullOrEmpty(qty))
            {
                return "Fill-in all the data columns!";
            }

            if(int.Parse(qty) > AlbumRepository.getAlbumStock(albumId))
            {
                return "We don't have enough album stock!";
            }

            List<Cart> cartList = cartHandler.getCartFromId(custId);
            if (cartList.Count != 0)
            {
                return "Cart is not empty!";
            }

            cartHandler.addToCart(custId, albumId, int.Parse(qty));

            return "Success!";
        }

        public void deleteCart(int custId)
        {
            List<Cart> cartList = cartHandler.getCartFromId(custId);

            if(cartList.Count != 0)
            {
                cartHandler.deleteCart(custId);
            }
        }
    }
}