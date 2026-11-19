using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;

namespace Lab_4.Objects
{
    [CsvRecord]
    public partial class Movie
    {
        // Protected fields accessible to this class and any derived classes
        [CsvColumn("show_id")]
        public string movieID {  get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        [CsvColumn("cast")]
        public string castMember { get; set; }
        public string country { get; set; }
        [CsvColumn("date_added")]
        public string dateAdded { get; set; }
        [CsvColumn("release_year")]
        public int dateReleased { get; set; }
        public string rating { get; set; }
        public string duration { get; set; }
        [CsvIgnore]
        public DateTime? lastWatched { get; set; }

        // Default constructor
        public Movie()
        {
        }

        // Parameterized constructor
        public Movie(string movieID, string type, string title, string director, string castMember, string country,
                     string dateAdded, int dateReleased, string rating, string duration, DateTime? lastWatched)
        {
            this.movieID = movieID;
            this.type = type;
            this.title = title;
            this.director = director;
            this.castMember = castMember;
            this.country = country;
            this.dateAdded = dateAdded;
            this.dateReleased = dateReleased;
            this.rating = rating;
            this.duration = duration;
            this.lastWatched = lastWatched;
        }

        public DateOnly getDate()
        {
            return DateOnly.ParseExact(dateAdded, "MMMM d, yyyy");
        }

        public string[] getCast()
        {
            return castMember.Split(", ");
        }
    }
}
