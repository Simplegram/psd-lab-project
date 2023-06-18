using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Handlers;

namespace PSD_KpopZtation.Controllers
{
    public class AlbumController
    {
        public AlbumHandler albumHandler;
        public AlbumController()
        {
            albumHandler = new AlbumHandler();
        }
        public List<Album> getArtistAlbums(string id)
        {
            return albumHandler.getArtistAlbums(id);
        }

        public string validateAlbum(string name, string desc, int price, int stock, string image, int artistId)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(price.ToString()) || string.IsNullOrEmpty(stock.ToString()) || string.IsNullOrEmpty(image))
            {
                return "Fill-in all the data columns!";
            }

            if (name.Length > 50)
            {
                return "Name must not be longer than 50 characters!";
            }
            if (desc.Length > 256)
            {
                return "Description must not be longer than 255 characters!";
            }
            if (price < 100000 || price > 1000000)
            {
                return "Price must be from 100k to 1m";
            }
            if (stock <= 0)
            {
                return "Stock must not be empty or below zero";
            }

            return "Success!";
        }

        public string validateAlbumChange(string name, string desc, int price, int stock, int albumId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(price.ToString()) || string.IsNullOrEmpty(stock.ToString()))
            {
                return "Fill-in all the data columns!";
            }

            if(name.Length > 50)
            {
                return "Name must not be longer than 50 characters!";
            }
            if(desc.Length > 256)
            {
                return "Description must not be longer than 255 characters!";
            }
            if(price < 100000 || price > 1000000)
            {
                return "Price must be from 100k to 1m";
            }
            if(stock <= 0)
            {
                return "Stock must not be empty or below zero";
            }

            albumHandler.updateAlbum(name, desc, price, stock, albumId);

            return "Success!";
        }
    }
}