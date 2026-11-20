using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Linq;
using Lab_4.Objects;
using Microsoft.VisualBasic.Logging;

namespace Lab_4
{
    internal class MockEndpoint
    {
        static private string netflixTitlesCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "netflix_titles.csv");
        static private string usersCSVPath = Path.Combine(Application.StartupPath, "CSVFiles", "users.csv");

        static public Movie? getMovie(string id)
        {
            var orders = CsvQueryable.FromFile<Movie>(netflixTitlesCSVPath);

            var match = orders.FirstOrDefault(m => m.movieID == id);

            return match;
        }

        static public List<Movie> getMovies()
        {
            using var reader = CsvReader.FromFile(netflixTitlesCSVPath);

            return reader.GetRecords<Movie>().ToList();
        }

        static public User? getUser(int id)
        {
            var movies = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = movies.FirstOrDefault(m => m.userID == id);

            return match;
        }

        static public List<User> getUsers()
        {
            using var reader = CsvReader.FromFile(usersCSVPath);

            return reader.GetRecords<User>().ToList();
        }

        static public List<User> getUsers(DateOnly date)
        {
            var users = CsvQueryable.FromFile<User>(usersCSVPath);

            var match = users.Where(u => u.lastActive >= date).ToList();

            return match;
        }
        static public bool addUser(string username, string password, string newMovieList)
        {
            using var reader = CsvReader.FromFile(usersCSVPath);
            var records = reader.GetRecords<User>().ToList();

            int count = records.Count;

            reader.Dispose();

            try
            {
                using (var writer = CsvWriter.ToFile(usersCSVPath))
                {
                    writer.WriteRecords(records);
                    writer.WriteRecord((count + 1).ToString(), username, password, "0", DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"), newMovieList);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        static public bool updateUser(int id, string newMovieList)
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
    }
}
