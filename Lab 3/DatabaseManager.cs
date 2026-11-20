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

        static public User? serverLogin(string username, string password)
        {
            return netflixAPI.validateLogin(username, password);
        }

        static public bool updateUser(int id, string watchHistory)
        {
            return netflixAPI.updateUserMovies(id, watchHistory);
        }

        static public bool createUser(string username, string password, string watchHistory)
        {
            return netflixAPI.addUser(username, password, watchHistory);
        }
    }
}
