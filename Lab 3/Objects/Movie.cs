using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3.Objects
{
    public class Movie
    {
        // Protected fields accessible to this class and any derived classes
        protected string movieID;
        protected string director;
        protected string castMember;
        protected string country;
        protected DateTime dateAdded;
        protected DateTime dateReleased;
        protected double rating;
        protected int duration;

        // Default constructor
        public Movie()
        {
        }

        // Parameterized constructor
        public Movie(string movieID, string director, string castMember, string country,
                     DateTime dateAdded, DateTime dateReleased, double rating, int duration)
        {
            this.movieID = movieID;
            this.director = director;
            this.castMember = castMember;
            this.country = country;
            this.dateAdded = dateAdded;
            this.dateReleased = dateReleased;
            this.rating = rating;
            this.duration = duration;
        }

        // Public properties (helpful for WinForms controls like DataGridView or ListBox)
        public string MovieID { get => movieID; set => movieID = value; }
        public string Director { get => director; set => director = value; }
        public string CastMember { get => castMember; set => castMember = value; }
        public string Country { get => country; set => country = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public DateTime DateReleased { get => dateReleased; set => dateReleased = value; }
        public double Rating { get => rating; set => rating = value; }
        public int Duration { get => duration; set => duration = value; }

        // Virtual method for polymorphism
        public virtual string GetDetails()
        {
            return $"ID: {movieID} | Directed by {director} | Rating: {rating}/10 ({duration} mins)";
        }
    }
}
