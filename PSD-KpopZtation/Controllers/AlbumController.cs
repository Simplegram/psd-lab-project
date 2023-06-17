using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Controllers
{
    public class AlbumController
    {
        AlbumRepository albumRepo;
        public AlbumController()
        {
            albumRepo = new AlbumRepository();
        }
        public List<Album> getArtistAlbums(string id)
        {
            return albumRepo.getArtistAlbums(id);
        }
    }
}