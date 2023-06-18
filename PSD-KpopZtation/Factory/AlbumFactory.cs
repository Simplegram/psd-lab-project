using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;


namespace PSD_KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(string name, string desc, int price, int stock, string image, int artistId)
        {
            Album album = new Album();

            album.AlbumID = AlbumRepository.getLastID() + 1;
            album.ArtistID = artistId;
            album.AlbumName = name;
            album.AlbumDescription = desc;
            album.AlbumPrice = price;
            album.AlbumStock = stock;
            album.AlbumImage = image;

            return album;
        }
    }
}