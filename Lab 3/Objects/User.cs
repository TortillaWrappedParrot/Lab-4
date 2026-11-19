using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    [CsvRecord]
    public partial class User
    {
        [CsvColumn("user_id")]
        public int userID;
        public string username;
        [CsvColumn("last_login")]
        public DateOnly lastActive;
        [CsvColumn("watch_history")]
        public string watchedMovies;

        public User(int userID, string username, DateOnly lastActive, string watchedMovies)
        {
            this.userID = userID;
            this.username = username;
            this.lastActive = lastActive;
            this.watchedMovies = watchedMovies;
        }

        public string getWatchedMovies()
        {
            return watchedMovies;
        }
    }
}
