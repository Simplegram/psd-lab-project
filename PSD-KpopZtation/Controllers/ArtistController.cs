using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Handlers;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Repositories;

namespace PSD_KpopZtation.Controllers
{
    public class ArtistController
    {
        public ArtistHandler artistHandler;
        ArtistRepository artistRepo;
        public ArtistController()
        {
            artistRepo = new ArtistRepository();
            artistHandler = new ArtistHandler();
        }
        public List<Artist> getAllArtist()
        {
            return artistRepo.getAllArtist();
        }
        public string validateArtist(string name, string image)
        {
            if (name.Length > 50)
            {
                return "Name must not be longer than 50 characters!";
            }

            artistHandler.addArtist(name, image);

            return "Success!";
        }
    }
}