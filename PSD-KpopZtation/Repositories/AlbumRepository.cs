using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Factory;

namespace PSD_KpopZtation.Repositories
{
    public class AlbumRepository
    {
        public static Database1Entities db = Database.getInstance();
        public void addAlbum(string name, string desc, int artistId, int price, int stock, string image)
        {
            Album album = AlbumFactory.createAlbum(name, desc, artistId, price, stock, image);

            db.Albums.Add(album);
            db.SaveChanges();
        }
        public List<Album> getArtistAlbums(string id)
        {
            return (from album in db.Albums where album.ArtistID.ToString().Equals(id) select album).ToList();
        }

        public static int getLastID()
        {
            int id = (from x in db.Albums select x.AlbumID).ToList().LastOrDefault();
            return id;
        }

        public void updateAlbum(string name, string desc, int price, int stock, int albumId)
        {
            Album album = (db.Albums.Find(albumId));

            album.AlbumName = name;
            album.AlbumDescription = desc;
            album.AlbumPrice = price;
            album.AlbumStock = stock;

            db.SaveChanges();
        }
    }
}