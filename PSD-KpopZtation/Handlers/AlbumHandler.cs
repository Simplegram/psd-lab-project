using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Handlers
{
    public class AlbumHandler
    {
        AlbumRepository albumRepo;
        public AlbumHandler()
        {
            albumRepo = new AlbumRepository();
        }
        public List<Album> getArtistAlbums(string id)
        {
            return albumRepo.getArtistAlbums(id);
        }

        public List<Album> getAlbumFromId(int albumId)
        {
            return albumRepo.getAlbumFromID(albumId);
        }

        public void addAlbum(string name, string desc, int price, int stock, string image, int albumId)
        {
            albumRepo.addAlbum(name, desc, price, stock, image, albumId);
        }

        public void updateAlbum(string name, string desc, int price, int stock, int albumId)
        {
            albumRepo.updateAlbum(name, desc, price, stock, albumId);
        }

        public bool checkImage(string image)
        {
            return albumRepo.checkImage(image);
        }

        public Album getAlbum(int albumId)
        {
            return albumRepo.getAlbum(albumId);
        }

        public void deleteAlbum(int albumId)
        {
            albumRepo.deleteAlbum(albumId);
        }
    }
}