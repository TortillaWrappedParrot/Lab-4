using CsvHelper;
using CsvHelper.Linq;
using Lab_4.Objects;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_4
{
    internal class MockEndpoint
    {
        private string netflixTitlesCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "netflix_titles.csv");
        private string usersCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "users.csv");

        public MockEndpoint() {
        }

        public Movie? getMovie(string id)
        {
            var orders = CsvQueryable.FromFile<Movie>(netflixTitlesCSVPath);

            var match = orders.FirstOrDefault(m => m.movieID == id);

            return match;
        }

        public List<Movie> getMovies()
        {
            using var reader = CsvReader.FromFile(netflixTitlesCSVPath);

            return reader.GetRecords<Movie>().ToList();
        }

        public User? getUser(int id)
        {
            var movies = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = movies.FirstOrDefault(m => m.userID == id);

            return match;
        }

        public List<User> getUsers()
        {
            using var reader = CsvReader.FromFile(usersCSVPath);

            return reader.GetRecords<User>().ToList();
        }

        public List<User> getUsers(DateOnly date)
        {
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = users.Where(u => u.lastActive >= date).ToList();

            return match;
        }
        public bool addUser(string username, string password, string newMovieList)
        {
            using var reader = CsvReader.FromFile(usersCSVPath);
            var users = reader.GetRecords<User>().ToList();

            if (users.Where(u => u.username == username).FirstOrDefault() != null)
            {
                return false;
            }

            reader.Dispose();

            int count = users.Count;

            try
            {
                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    writer.WriteRecords(users);
                    writer.WriteRecord((count + 1).ToString(), username, password, DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"), newMovieList, "False");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateUserStatus(int id)
        {
            using var reader = CsvReader.FromFile(usersCSVPath);
            List<User> records = reader.GetRecords<User>().ToList();

            User? targetUser = records.FirstOrDefault(m => m.userID == id);

            reader.Dispose();

            if (targetUser != null)
            {
                targetUser.lastActive = DateOnly.FromDateTime(DateTime.Now);

                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    writer.WriteRecords(records);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUserMovies(int id, string newMovieList)
        {
            using var reader = CsvReader.FromFile(usersCSVPath);
            List<User> records = reader.GetRecords<User>().ToList();

            User? targetUser = records.FirstOrDefault(m => m.userID == id);

            reader.Dispose();

            if (targetUser != null)
            {
                targetUser.watchedMovies = newMovieList;

                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    writer.WriteRecords(records);
                }

                return true;
            } else
            {
                return false;
            }
        }

        public User? validateLogin(string username, string password)
        {
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = users.Where(u => u.username == username).FirstOrDefault();

            if (match != null && match.requestPassword() == password)
            {
                updateUserStatus(match.userID);

                return match;
            }

            return null;
        }
    }
}
