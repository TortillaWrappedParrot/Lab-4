using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    /// <summary>
    /// Represents an active user with a watch history and information.
    /// </summary>
    [CsvRecord]
    public partial class User
    {
        /// <value>Property <c>userID</c> represents the user's id as in the CSV file</value>
        [CsvColumn("user_id")]
        public int userID;
        /// <value>Property <c>username</c> represents the user's username in the CSV file</value>
        public string username;
        /// <value>Property <c>username</c> represents the user's password in the CSV file</value>
        private string password;
        /// <value>Property <c>lastActive</c> represents the the last time the user has logged in</value>
        [CsvColumn("last_login")]
        public DateOnly lastActive;
        /// <value>Property <c>watchedMovies</c> represents the user's watch history in this format s1&2026-11-20|s2&2026-11-20. Where |
        /// divides watched movies or shows and the & represents the movie's id and last watched</value>
        [CsvColumn("watch_history")]
        public string watchedMovies;
        /// <value>Property <c>adminStatus</c> represents the user's admin status and privelage rights</value>
        [CsvColumn("admin_status")]
        private bool adminStatus;

        /// <summary>
        /// Creates a new User given the information from the CSV. Assigned by CsvHelper records automatically.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="lastActive"></param>
        /// <param name="watchedMovies"></param>
        /// <param name="adminStatus"></param>
        public User(int userID, string username, string password, DateOnly lastActive, string watchedMovies, bool adminStatus)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.lastActive = lastActive;
            this.watchedMovies = watchedMovies;
            this.adminStatus = adminStatus;
        }

        /// <summary>
        /// Returns the watchedMovies field.
        /// </summary>
        /// <returns>watchedMovies field</returns>
        public string getWatchedMovies()
        {
            return watchedMovies;
        }

        /// <summary>
        /// Returns the User's admin status.
        /// </summary>
        /// <returns>Returns adminStatus field</returns>
        public bool getStatus()
        {
            return adminStatus;
        }

        /// <summary>
        /// Returns the User's password
        /// </summary>
        /// <returns>Returns password field</returns>
        public string requestPassword()
        {
            return password;
        }
    }
}
