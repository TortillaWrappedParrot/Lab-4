using Lab_4.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    internal class DatabaseManager
    {
        static private MockEndpoint netflixAPI = new MockEndpoint();

        static public List<Movie> requestMovies()
        {
            return netflixAPI.getMovies();
        }
    }
}
