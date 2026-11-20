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

        static public bool createDummies(int userAmountNum, int movieAmountNum, int oldestYearNum)
        {
            List<Movie> movieList = DatabaseManager.requestMovies();

            DateOnly dayNumberMin = DateOnly.FromDateTime(DateTime.Now).AddMonths(-(oldestYearNum));
            DateOnly dayNumberMax = DateOnly.FromDateTime(DateTime.Now);

            for (int i = 0; i < userAmountNum; i++)
            {
                StringBuilder sb = new StringBuilder();
                List<Movie> chosenMovies = movieList.Distinct().OrderBy(_ => Random.Shared.Next()).Take(movieAmountNum).ToList();

                foreach (Movie movie in chosenMovies)
                {
                    if (movie.getDate() != null && movie.getDate() > dayNumberMin)
                    {
                        DateOnly dateCheck = (DateOnly)movie.getDate();

                        DateOnly selectedDate = DateOnly.FromDayNumber(Random.Shared.Next(dateCheck.DayNumber, dayNumberMax.DayNumber + 1));
                        sb.Append(movie.movieID + "&" + selectedDate.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        DateOnly selectedDate = DateOnly.FromDayNumber(Random.Shared.Next(dayNumberMin.DayNumber, dayNumberMax.DayNumber + 1));
                        sb.Append(movie.movieID + "&" + selectedDate.ToString("yyyy-MM-dd"));
                    }

                    sb.Append('|');
                }

                sb.Remove(sb.Length - 1, 1);

                bool check = DatabaseManager.createUser(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), sb.ToString());

                if (check == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
