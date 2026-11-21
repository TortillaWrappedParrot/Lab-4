using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;

namespace Lab_4.Objects
{
    /// <summary>
    /// Primary class for Movie object utilizing CsvHelper.
    /// </summary>
    [CsvRecord] //Marks it as a record for the query functions
    public partial class Movie
    {
        //Fields

        /// <value>Property <c>movieID</c> represents the movie's id as in the CSV file</value>
        ///CsvColumn assigns a variable to the CSV file header without needing matching names, show_id = movieID for record keeping
        [CsvColumn("show_id")]
        public string movieID {  get; set; }
        /// <value>Property <c>type</c> represents if it is a series or a movie</value>
        public string type { get; set; }
        /// <value>Property <c>title</c> represents the movie's title</value>
        public string title { get; set; }
        /// <value>Property <c>director</c> represents the movie's director or directors</value>
        public string director { get; set; }
        /// <value>Property <c>genre</c> represents the movie's cast members as one string seperated by ", "</value>
        [CsvColumn("cast")]
        public string castMembers { get; set; }
        /// <value>Property <c>country</c> represents the movie's origin country</value>
        public string country { get; set; }
        /// <value>Property <c>dateAdded</c> represents the date the movie was added to the catalog</value>
        [CsvColumn("date_added")]
        public string dateAdded { get; set; }
        /// <value>Property <c>dateReleased</c> represents the year the movie was released as an int</value>
        [CsvColumn("release_year")]
        public int dateReleased { get; set; }
        /// <value>Property <c>rating</c> represents the movie's MPA (maybe, not actually too sure about where these ratings are from) age rating</value>
        public string rating { get; set; }
        /// <value>Property <c>duration</c> represents the movie's duration in minutes as a string</value>
        public string duration { get; set; }
        /// <value>Property <c>listedIn</c> represents the movie's genres as a string instead of list such as Action or Comedies</value>
        [CsvColumn("listed_in")]
        public string listedIn { get; set; }
        /// <value>Property <c>description</c> represents the the movie's given description</value>
        public string description { get; set; }
        /// <value>Property <c>lastWatched</c> represents the last time the movie was seen, this is used for User's and not CSV</value>
        /// CsvIgnore tells the record to ignore it during creation to prevent an error
        [CsvIgnore]
        public DateTime? lastWatched { get; set; }

        /// <summary>
        /// Default contructor for Movie object. Required for CsvHelper to function for assigning the lines to variables, without it there is an
        /// exception on start.
        /// </summary>
        /// 
        /// <remarks>
        /// I do believe the issue with CsvHelper requiring it might just be due to how its set up as the User class does not have this same restriction.
        /// </remarks>
        public Movie()
        {
        }

        /// <summary>
        /// Creates a new Movie when neccessary or when the exact details are known.
        /// </summary>
        /// <param name="movieID"></param>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="director"></param>
        /// <param name="castMember"></param>
        /// <param name="country"></param>
        /// <param name="dateAdded"></param>
        /// <param name="dateReleased"></param>
        /// <param name="rating"></param>
        /// <param name="listedIn"></param>
        /// <param name="duration"></param>
        /// <param name="description"></param>
        /// <param name="lastWatched"></param>
        public Movie(string movieID, string type, string title, string director, string castMember, string country,
                     string dateAdded, int dateReleased, string rating, string listedIn, string duration, string description, DateTime? lastWatched)
        {
            this.movieID = movieID;
            this.type = type;
            this.title = title;
            this.director = director;
            this.castMembers = castMember;
            this.country = country;
            this.dateAdded = dateAdded;
            this.dateReleased = dateReleased;
            this.rating = rating;
            this.duration = duration;
            this.description = description;
            this.listedIn = listedIn;
            this.lastWatched = lastWatched;
        }

        /// <summary>
        /// Returns string date stored as DateOnly format or null depending on if there is an exception or not.
        /// </summary>
        /// <returns>
        /// A DateOnly represnting the Date it was added to the catalog. Used to determine impossible watch dates for dummy accounts.
        /// </returns>
        /// 
        /// <remarks>
        /// Not sure which Movie exactly, but one seems to have a malformed date as it causes a crash when creating dummies resulting in this safety check.
        /// </remarks>
        public DateOnly? getDate()
        {
            try
            {
                DateOnly returnDate = DateOnly.ParseExact(dateAdded.Trim(), "MMMM d, yyyy");
                return returnDate;
            } catch (Exception) 
            { 
                return null; 
            }
        }

        /// <summary>
        /// Custom string of fields to return a useful display label for listbox. Without this only one field could be displayed at a time.
        /// </summary>
        public string DisplayText => $"{title} - {type} - {rating}";

        /// <summary>
        /// Used for right side description to showcase more details about the movie without taking away from the compact nature.
        /// </summary>
        public string DescriptionText => $"{description}\nGenres: {listedIn}\nDirector: {director}\nCast: {castMembers}\nYear Released: {dateReleased}";
    }
}
