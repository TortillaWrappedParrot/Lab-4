using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    public class User
    {
        public int userID;
        public string username;
        public DateTime lastActive;
        public List<UserMovie> watchedMovies;


        public User()
        {
        }

        public User(int userID, string username, DateTime lastActive, List<UserMovie> watchedMovies)
        {
            this.userID = userID;
            this.username = username;
            this.lastActive = lastActive;
            this.watchedMovies = watchedMovies;
        }

        public List<UserMovie> getWatchedMovies()
        {
            return watchedMovies;
        }
    }
}
