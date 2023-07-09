using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD_KpopZtation.Models;
using PSD_KpopZtation.Handlers;
using PSD_KpopZtation.Factory;

namespace PSD_KpopZtation.Repositories
{
    public class ArtistRepository
    {
        Database1Entities db = Database.getInstance();

        public ArtistHandler artistHandler;
        public List<Artist> getAllArtist()
        {
            return (from artist in db.Artists select artist).ToList();
        }

        public void addArtist(string name, string image)
        {
            Artist artist = ArtistFactory.createArtist(name, image);

            int lastArtistID = getLastID() + 1;
            db.Artists.Add(artist);
            db.SaveChanges();
        }

        public string validateArtist(string name, string image, int artistId)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(image))
            {
                return "Fill-in all the data columns!";
            }

            if (name.Length > 50)
            {
                return "Name must not be longer than 50 characters!";
            }

            if (artistHandler.checkImage(image))
            {
                return "Image already exists!";
            }

            artistHandler.addArtist(name, image);

            return "Success!";
        }

        public int getLastID()
        {
            int id = (from x in db.Artists select x.ArtistID).ToList().LastOrDefault();
            if (id == 0)
            {
                return 0;
            }
            else
            {
                return id;
            }
        }

        internal bool CheckImage(string image)
        {
            throw new NotImplementedException();
        }

        private int getArtistLastID(int artistId)
        {
            throw new NotImplementedException();
        }
        public bool checkImage(string image)
        {
            string searchImage = (from x in db.Artists where x.ArtistImage.Equals(image) select x.ArtistImage).ToList().LastOrDefault();

            if (string.IsNullOrEmpty(searchImage))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}