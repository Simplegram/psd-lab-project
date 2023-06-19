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
        public void addAlbum(string name, string desc, int price, int stock, string image, int artistId)
        {
            Album album = AlbumFactory.createAlbum(name, desc, price, stock, image, artistId);

            int lastAlbumID = getArtistLastAlbumID(artistId);

            if (lastAlbumID == 0)
            {
                album.AlbumID = (artistId * 10000) + 1;
            } 
            else
            {
                album.AlbumID = getArtistLastAlbumID(artistId) + 1;
            }

            db.Albums.Add(album);
            db.SaveChanges();
        }
        public List<Album> getArtistAlbums(string artistId)
        {
            return (from album in db.Albums where album.ArtistID.ToString().Equals(artistId) select album).ToList();
        }

        public List<Album> getAlbumFromID(int albumId)
        {
            return (from album in db.Albums where album.AlbumID == albumId select album).ToList();
        }


        public static int getArtistLastAlbumID(int artistId)
        {
            int id = (from x in db.Albums where x.ArtistID == artistId select x.AlbumID).ToList().LastOrDefault();
            return id;
        }

        public static int getLastID()
        {
            int id = (from x in db.Albums select x.AlbumID).ToList().LastOrDefault();
            if (id == 0)
            {
                return -1;
            }
            else
            {
                return id;
            }
        }

        public Album getAlbum(int albumId)
        {
            return (from x in db.Albums where x.AlbumID == albumId select x).FirstOrDefault();
        }

        public void deleteAlbum(int albumId)
        {
            Album album = getAlbum(albumId);
            db.Albums.Remove(album);
            db.SaveChanges();
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

        public bool checkImage(string image)
        {
            string searchImage = (from x in db.Albums where x.AlbumImage.Equals(image) select x.AlbumImage).ToList().LastOrDefault();
            System.Diagnostics.Debug.WriteLine(searchImage);

            if (string.IsNullOrEmpty(searchImage))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int getAlbumStock(int albumId)
        {
            int stock = (from x in db.Albums where x.AlbumID == albumId select x.AlbumStock).ToList().LastOrDefault();
            return stock;
        }
    }
}