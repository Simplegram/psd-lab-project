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
        AlbumHandler albumHandler;
        public AlbumController()
        {
            albumHandler = new AlbumHandler();
        }
        public List<Album> getArtistAlbums(string id)
        {
            return albumHandler.getArtistAlbums(id);
        }
    }
}