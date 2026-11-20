using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    public class Filter
    {
        public string? keyword;
        public string? title;
        public string? director;
        public int? releaseYear;
        public string? genre;

        public Filter(string keyword, string title, string director, string releaseYear, string genre)
        {
            if (!keyword.IsWhiteSpace())
            {
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
                try
                {
                    int year = int.Parse(releaseYear);
                    this.releaseYear = year;
                } catch (Exception)
                {
                    
                }
            }

            if (!genre.IsWhiteSpace())
            {
                this.genre = genre.ToLower();
            }
        }
    }
}
