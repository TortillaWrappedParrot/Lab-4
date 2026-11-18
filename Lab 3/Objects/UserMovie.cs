using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3.Objects
{
    public class UserMovie : Movie
    {
        protected DateTime lastWatched;

        // Default constructor
        public UserMovie() : base()
        {
        }

        // Parameterized constructor passing base fields up to the Movie class
        public UserMovie(string movieID, string director, string castMember, string country,
                         DateTime dateAdded, DateTime dateReleased, double rating, int duration,
                         DateTime lastWatched)
            : base(movieID, director, castMember, country, dateAdded, dateReleased, rating, duration)
        {
            this.lastWatched = lastWatched;
        }

        // Public property for lastWatched
        public DateTime LastWatched { get => lastWatched; set => lastWatched = value; }

        // Overriding the base method to include user-specific info
        public override string GetDetails()
        {
            return $"{base.GetDetails()} | Last Watched: {lastWatched.ToShortDateString()}";
        }
    }
}
