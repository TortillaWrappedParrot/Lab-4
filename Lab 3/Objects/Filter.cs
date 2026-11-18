using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    public class Filter
    {
        protected string? director;
        protected string? castMember;
        protected string? country;
        protected DateTime? dateAdded;
        protected DateTime? dateReleased;
        protected double? rating;
        protected int? duration;

        public Filter(string director, string castMember, string country, DateTime dateAdded, DateTime dateReleased, double rating, int duration)
        {
            this.director = director;
            this.castMember = castMember;
            this.country = country;
            this.dateAdded = dateAdded;
            this.dateReleased = dateReleased;
            this.rating = rating;
            this.duration = duration;
        }
    }
}
