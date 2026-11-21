using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    /// <summary>
    /// Acts as a container for multiple variables allowing for either linq queries or for loops depending on situation
    /// </summary>
    public class Filter
    {
        //Fields

        /// <value>Property <c>keyword</c> represents the keyword used for description filtering</value>
        public string? keyword;
        /// <value>Property <c>title</c> represents what the movie's title should contain</value>
        public string? title;
        /// <value>Property <c>title</c> represents the name the director should contain</value>
        public string? director;
        /// <value>Property <c>releaseYear</c> represents year the movie released as an it</value>
        public int? releaseYear;
        /// <value>Property <c>genre</c> represents the movie's genres as a string instead of list</value>
        public string? genre;

        /// <summary>
        /// Creates a new filter object to store specific data./> class.
        /// </summary>
        /// <param name="keyword">The target description keyword.</param>
        /// <param name="title">The target title.</param>
        /// <param name="director">The target director.</param>
        /// <param name="releaseYear">The target release year.</param>
        /// <param name="genre">The target genre.</param>
        public Filter(string keyword, string title, string director, string releaseYear, string genre)
        {
            //Standardize all inputs for null
            
            //Check if its not just whitespace first, its trimmed before input
            if (!keyword.IsWhiteSpace())
            {
                //lowercase it as well to set a standard for all variables
                this.keyword = keyword.ToLower();
            }

            if (!title.IsWhiteSpace())
            {
                this.title = title.ToLower();
            }

            if (!director.IsWhiteSpace())
            {
                this.director = director.ToLower();
            }

            if (!releaseYear.IsWhiteSpace())
            {
                //Try catch to prevent an exception due to invalid parse
                try
                {
                    int year = int.Parse(releaseYear);
                    this.releaseYear = year;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (!genre.IsWhiteSpace())
            {
                this.genre = genre.ToLower();
            }
        }
    }
}
