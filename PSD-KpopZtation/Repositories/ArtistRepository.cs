using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;

namespace PSD_KpopZtation.Repositories
{
    public class ArtistRepository
    {
        Database1Entities db = Database.getInstance();
        public List<Artist> getAllArtist()
        {
            return (from artist in db.Artists select artist).ToList();
        }
    }
}