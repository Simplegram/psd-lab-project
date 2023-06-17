using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Repositories
{
    public class AlbumRepository
    {
        Database1Entities db = Database.getInstance();
        public List<Album> getArtistAlbums(string id)
        {
            return (from album in db.Albums where album.ArtistID.ToString().Equals(id) select album).ToList();
        }
    }
}