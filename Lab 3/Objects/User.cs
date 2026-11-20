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
        private string password;
        [CsvColumn("last_login")]
        public DateOnly lastActive;
        [CsvColumn("watch_history")]
        public string watchedMovies;
        [CsvColumn("admin_status")]
        private bool adminStatus;

        public User(int userID, string username, string password, DateOnly lastActive, string watchedMovies, bool adminStatus)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.lastActive = lastActive;
            this.watchedMovies = watchedMovies;
            this.adminStatus = adminStatus;
        }

        public string getWatchedMovies()
        {
            return watchedMovies;
        }

        public string requestPassword()
        {
            return password;
        }
    }
}
