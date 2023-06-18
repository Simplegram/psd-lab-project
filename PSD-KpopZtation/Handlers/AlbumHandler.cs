﻿using System;
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

        public void addAlbum(string name, string desc, int price, int stock, int albumId)
        {
            albumRepo.updateAlbum(name, desc, price, stock, albumId);
        }

        public void updateAlbum(string name, string desc, int price, int stock, int albumId)
        {
            albumRepo.updateAlbum(name, desc, price, stock, albumId);
        }
    }
}