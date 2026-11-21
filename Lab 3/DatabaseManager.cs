using Lab_4.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lab_4
{
    internal class DatabaseManager
    {
        static private MockEndpoint endpointAPI = new MockEndpoint();

        public List<Movie> requestMovies()
        {
            return endpointAPI.getMovies();
        }

        public User? serverLogin(string username, string password)
        {
            return endpointAPI.validateLogin(username, password);
        }

        public bool updateUser(int id, string watchHistory)
        {
            return endpointAPI.updateUserMovies(id, watchHistory);
        }

        public bool createUser(string username, string password, string watchHistory)
        {
            return endpointAPI.addUser(username, password, watchHistory);
        }

        private string[] trendFields = ["Genre", "Title", "CastMember", "Director"];
        private string[] trendProperties = ["listedIn", "title", "castMembers", "director"];

        public Dictionary<string, string> getUserTrends(DateOnly goalDate)
        {
            Dictionary<string, string> returnTable = new()
            {
                ["Trending Genre"] = "",
                ["Trending Movie"] = "",
                ["Trending Cast Member"] = "",
                ["Trending Director"] = "",
                ["Genre + Title"] = "",
                ["Genre + CastMember"] = "",
                ["Genre + Director"] = "",
                ["Title + CastMember"] = "",
                ["Title + Director"] = "",
                ["CastMember + Director"] = ""
            };
            List<User> userList = endpointAPI.getUsers();

            Dictionary<string, List<string>> trendCount = new()
            {
                ["Trending Genre"] = [],
                ["Trending Movie"] = [],
                ["Trending Cast Member"] = [],
                ["Trending Director"] = [],
                ["Genre + Title"] = [],
                ["Genre + CastMember"] = [],
                ["Genre + Director"] = [],
                ["Title + CastMember"] = [],
                ["Title + Director"] = [],
                ["CastMember + Director"] = []
            };

            foreach (User user in userList)
            {
                string[] watchHistory = user.getWatchedMovies().Split("|");

                foreach (string movie in watchHistory)
                {
                    string movieID = movie.Split("&")[0];
                    string watchDate = movie.Split("&")[1];

                    Movie? targetMovie = endpointAPI.getMovie(movieID);
                    DateOnly movieDate;

                    bool movieDateCheck = DateOnly.TryParseExact(watchDate, "yyyy-MM-dd", out movieDate);

                    if (targetMovie != null && movieDate >= goalDate)
                    {
                        

                        string[] listedGenres = targetMovie.listedIn.Split(", ");

                        foreach (string genre in listedGenres)
                        {
                            if (!genre.Trim().IsWhiteSpace())
                            {
                                trendCount["Trending Genre"].Add(genre);
                            }
                        }

                        trendCount["Trending Movie"].Add(targetMovie.title);

                        //Cast counter

                        string[] listedCast = targetMovie.castMembers.Split(", ");

                        foreach (string castMember in listedCast)
                        {
                            if (!castMember.Trim().IsWhiteSpace())
                            {
                                trendCount["Trending Cast Member"].Add(castMember);
                            }
                        }

                        if (!targetMovie.director.Trim().IsWhiteSpace())
                        {
                            trendCount["Trending Director"].Add(targetMovie.director);
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            string firstValue = (string)targetMovie.GetType().GetProperty(trendProperties[i]).GetValue(targetMovie, null);

                            for (int j = i + 1; j < 4; j++)
                            {
                                
                                string secondValue = (string)targetMovie.GetType().GetProperty(trendProperties[j]).GetValue(targetMovie, null);

                                if (firstValue.Trim().IsWhiteSpace() || secondValue.Trim().IsWhiteSpace())
                                {
                                    continue;
                                }

                                if (firstValue.Split(", ").Length > 1 && secondValue.Split(", ").Length <= 1)
                                {
                                    string[] splitFirst = firstValue.Split(", ");

                                    foreach (string splitFirstValue in splitFirst)
                                    {
                                        trendCount[trendFields[i] + " + " + trendFields[j]].Add(splitFirstValue + " & " + secondValue);
                                    }

                                    continue;
                                }

                                if (firstValue.Split(", ").Length <= 1 && secondValue.Split(", ").Length > 1)
                                {
                                    string[] splitSecond = secondValue.Split(", ");

                                    foreach (string splitSecondValue in splitSecond)
                                    {
                                        trendCount[trendFields[i] + " + " + trendFields[j]].Add(firstValue + " & " + splitSecondValue);
                                    }

                                    continue;
                                }

                                if (firstValue.Split(", ").Length > 1 && secondValue.Split(", ").Length > 1)
                                {
                                    string[] splitFirst = firstValue.Split(", ");
                                    string[] splitSecond = secondValue.Split(", ");

                                    foreach (string splitFirstValue in splitFirst)
                                    {
                                        foreach (string splitSecondValue in splitSecond)
                                        {
                                            trendCount[trendFields[i] + " + " + trendFields[j]].Add(splitFirstValue + " & " + splitSecondValue);
                                        }
                                    }

                                    continue;
                                }

                                if (firstValue.Split(", ").Length <= 1 && secondValue.Split(", ").Length <= 1)
                                {
                                    trendCount[trendFields[i] + " + " + trendFields[j]].Add(firstValue + " & " + secondValue);
                                }
                            }
                        }
                    }
                }
            }

            foreach(KeyValuePair<string, List<string>> entry in trendCount)
            {
                returnTable[entry.Key] = entry.Value.GroupBy(x => x)
                          .OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            }

            return returnTable;
        }

        public bool createDummies(int userAmountNum, int movieAmountNum, int oldestYearNum)
        {
            List<Movie> movieList = requestMovies();

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

                bool check = createUser(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), sb.ToString());

                if (check == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
