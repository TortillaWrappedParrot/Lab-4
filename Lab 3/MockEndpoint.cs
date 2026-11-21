using CsvHelper;
using CsvHelper.Linq;
using Lab_4.Objects;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab_4
{
    /// <summary>
    /// Acts as the endpoint of the program which has sole access to the CVS files
    /// </summary>
    internal class MockEndpoint
    {
        /// <value>Property <c>netflixTitlesCSVPath</c> represents the path to the netflix_titles.csv, Path.Combine ensures that the files are always found in the same directory</value>
        private string netflixTitlesCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "netflix_titles.csv");
        /// <value>Property <c>netflixTitlesCSVPath</c> represents the path to the users.csv</value>
        private string usersCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "users.csv");

        /// <summary>
        /// Connection point to the DatabaseManager
        /// </summary>
        public MockEndpoint() {
        }

        /// <summary>
        /// Returns either null or target Movie
        /// </summary>
        /// <param name="id">Target Movie id</param>
        /// <returns>Movie or null</returns>
        public Movie? getMovie(string id)
        {
            //CsvQueryable from CsvHelper.Linq allows Linq queries without opening a reader
            var orders = CsvQueryable.FromFile<Movie>(netflixTitlesCSVPath);

            //Get the first result or null if not
            //var is recomended just in case
            var match = orders.FirstOrDefault(m => m.movieID == id);

            return match;
        }

        /// <summary>
        /// Returns all records as a Movie list from CSV file
        /// </summary>
        /// <returns>Movie list</returns>
        public List<Movie> getMovies()
        {
            //using ensures cleanup when function is out of scope
            using var reader = CsvReader.FromFile(netflixTitlesCSVPath);

            //Returns the records as a list
            return reader.GetRecords<Movie>().ToList();
        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">Target User id</param>
        /// <returns>User or null</returns>
        public User? getUser(int id)
        {
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = users.FirstOrDefault(m => m.userID == id);

            return match;
        }

        /// <summary>
        /// Returns all Users from CSV file
        /// </summary>
        /// <returns>User list</returns>
        public List<User> getUsers()
        {
            using var reader = CsvReader.FromFile(usersCSVPath);

            return reader.GetRecords<User>().ToList();
        }

        /// <summary>
        /// Returns all users who have logged in after a certain time
        /// </summary>
        /// <param name="date">The target date</param>
        /// <returns>User list</returns>
        public List<User> getUsers(DateOnly date)
        {
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = users.Where(u => u.lastActive >= date).ToList();

            return match;
        }

        /// <summary>
        /// Adds a user to the CSV file with a username, password, and newMovieList
        /// </summary>
        /// <param name="username">New username</param>
        /// <param name="password">New password</param>
        /// <param name="newMovieList">new watchHistory</param>
        /// <returns>True if it succeeds and false if it fails</returns>
        public bool addUser(string username, string password, string newMovieList)
        {
            //Open reader and store the current records
            using var reader = CsvReader.FromFile(usersCSVPath);
            var users = reader.GetRecords<User>().ToList();

            //Check if the username is already taken
            if (users.Where(u => u.username == username).FirstOrDefault() != null)
            {
                reader.Dispose();
                return false;
            }

            //Dispose of reader before opening writer
            reader.Dispose();

            //Get a count of current amount of users
            int count = users.Count;

            //Try/Catch to prevent writer access exception
            try
            {
                //Open writer
                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    //Write original records it it overwrites the entire file
                    writer.WriteRecords(users);

                    //Add new user
                    writer.WriteRecord((count + 1).ToString(), username, password, DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"), newMovieList, "False");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates User last online status
        /// </summary>
        /// <param name="id">The target id</param>
        /// <returns>True if it succeeds and false if it fails</returns>
        public bool updateUserStatus(int id)
        {
            //Open reader
            using var reader = CsvReader.FromFile(usersCSVPath);
            List<User> records = reader.GetRecords<User>().ToList();

            //Find user
            User? targetUser = records.FirstOrDefault(m => m.userID == id);

            //Dispose reader
            reader.Dispose();

            //Check if user is null
            if (targetUser != null)
            {
                //Update lastActive
                targetUser.lastActive = DateOnly.FromDateTime(DateTime.Now);

                //Open writer
                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    //Rewrite records with updated value
                    writer.WriteRecords(records);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates target User's watchHistory
        /// </summary>
        /// <param name="id">Target User id</param>
        /// <param name="newMovieList">Targe user new watchHistory</param>
        /// <returns>True if it succeeds and false if it fails</returns>
        public bool updateUserMovies(int id, string newMovieList)
        {
            //Open reader and save records
            using var reader = CsvReader.FromFile(usersCSVPath);
            List<User> records = reader.GetRecords<User>().ToList();

            //Find user
            User? targetUser = records.FirstOrDefault(m => m.userID == id);

            //Dispose reader
            reader.Dispose();

            //Check if user is null
            if (targetUser != null)
            {
                //Updated watchedMovies
                targetUser.watchedMovies = newMovieList;

                //Open writer
                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    //Rewrite records
                    writer.WriteRecords(records);
                }

                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks a User's credentials and returns the User object if it succeeds
        /// </summary>
        /// <param name="username">Target username</param>
        /// <param name="password">Target password</param>
        /// <returns>User</returns>
        public User? validateLogin(string username, string password)
        {
            //Get users
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            //Check for if the username exists
            var match = users.Where(u => u.username == username).FirstOrDefault();

            //Check if the password matches
            if (match != null && match.requestPassword() == password)
            {
                //Update login date
                updateUserStatus(match.userID);

                //Return User object
                return match;
            }

            return null;
        }
    }
}
