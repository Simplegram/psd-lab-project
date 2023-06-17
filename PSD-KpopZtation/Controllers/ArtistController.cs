using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Controllers
{
    public class ArtistController
    {
        ArtistRepository artistRepo;
        public ArtistController()
        {
            artistRepo = new ArtistRepository();
        }
        public List<Artist> getAllArtist()
        {
            return artistRepo.getAllArtist();
        }
    }
}