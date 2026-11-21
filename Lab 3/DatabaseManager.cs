using Lab_4.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lab_4
{
    /// <summary>
    /// The bridge between the database and the client.
    /// </summary>
    internal class DatabaseManager
    {
        /// <value>Property <c>endpointAPI</c> represents connection the external API that manages the CSV files</value>
        static private MockEndpoint endpointAPI = new MockEndpoint();

        /// <summary>
        /// Invokes the server for all movies from the CSV file
        /// </summary>
        /// <returns>Movie list</returns>
        public List<Movie> requestMovies()
        {
            return endpointAPI.getMovies();
        }

        /// <summary>
        /// Passes the credentials to the server and returns the provided User object if they were valid or null if they were not
        /// </summary>
        /// <param name="username">username to validate</param>
        /// <param name="password">password to validate</param>
        /// <returns></returns>
        public User? serverLogin(string username, string password)
        {
            return endpointAPI.validateLogin(username, password);
        }

        /// <summary>
        /// Updates the specified User's id with the new watchHistory
        /// </summary>
        /// <param name="id">The User id</param>
        /// <param name="watchHistory">The new watch history</param>
        /// <returns>True if it succeeds and false if it fails</returns>
        public bool updateUser(int id, string watchHistory)
        {
            return endpointAPI.updateUserMovies(id, watchHistory);
        }

        /// <summary>
        /// Attempts to create a new user with the specified details.
        /// </summary>
        /// <param name="username">The new username</param>
        /// <param name="password">The new password</param>
        /// <param name="watchHistory">The new watch history</param>
        /// <returns>True if it succeeds and false if it fails</returns>
        public bool createUser(string username, string password, string watchHistory)
        {
            return endpointAPI.addUser(username, password, watchHistory);
        }

        /// <value>Property <c>trendFiles</c> the different target trend values wanted</value>
        private string[] trendFields = ["Genre", "Title", "CastMember", "Director"];
        /// <value>Property <c>trendProperties</c> represents the object field counterpart to the values</value>
        private string[] trendProperties = ["listedIn", "title", "castMembers", "director"];

        /// <summary>
        /// Returns 10 fields of trend data based on User's watch history after the given date. This is done with duplicates and a for loop that gets all pairs from
        /// 4 fields which is 6 total pairs. The most popular of each category are also returned.
        /// </summary>
        /// <param name="goalDate">The oldest date that should be considered</param>
        /// <returns>A dictonary contaning relevant trend data.</returns>
        /// 
        /// <remarks>
        /// This function takes a while to work during practice and im not sure if it can be improved as a single loop through a movie takes about 10ms,
        /// however with each user having 10 movies thats 100ms per user meaning 10 users is a whole second. I would love to know if there was a better way around this
        /// but I feel like this is a limitation that I do not know how to go past.
        /// </remarks>
        public Dictionary<string, string> getUserTrends(DateOnly goalDate)
        {
            //The table to be returned containg a string value to be used in a listbox
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
            //A list of all users from the CSV file
            List<User> userList = endpointAPI.getUsers();

            //A dictionary with a list to store duplicates and count them afterwards
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

            //Loop through each user
            foreach (User user in userList)
            {
                //Get all watched movies
                string[] watchHistory = user.getWatchedMovies().Split("|");

                foreach (string movie in watchHistory)
                {
                    //Split into id and watch date
                    string movieID = movie.Split("&")[0];
                    string watchDate = movie.Split("&")[1];

                    Movie? targetMovie = endpointAPI.getMovie(movieID); //Get movie from API as no local copy
                    DateOnly movieDate; //Create variable for out

                    //Attempt parse
                    bool movieDateCheck = DateOnly.TryParseExact(watchDate, "yyyy-MM-dd", out movieDate);

                    //If it fails go to next
                    if (movieDateCheck == false)
                    {
                        continue;
                    }

                    //Check if it is not null and is recent enough
                    if (targetMovie != null && movieDate >= goalDate)
                    {
                        //Store genres for most trending
                        string[] listedGenres = targetMovie.listedIn.Split(", ");

                        foreach (string genre in listedGenres)
                        {
                            //Check for empty genres (dont believe there are but some weird edge cases have occured)
                            if (!genre.Trim().IsWhiteSpace())
                            {
                                trendCount["Trending Genre"].Add(genre);
                            }
                        }

                        //Store titles for most trending
                        trendCount["Trending Movie"].Add(targetMovie.title);

                        //Store cast for most trending
                        string[] listedCast = targetMovie.castMembers.Split(", ");

                        foreach (string castMember in listedCast)
                        {
                            //Check for empty cast sets
                            if (!castMember.Trim().IsWhiteSpace())
                            {
                                trendCount["Trending Cast Member"].Add(castMember);
                            }
                        }

                        //Store directors for most trending and check for empty sets
                        if (!targetMovie.director.Trim().IsWhiteSpace())
                        {
                            trendCount["Trending Director"].Add(targetMovie.director);
                        }

                        //Loops 6 times to get all needed trend data
                        //A -> B
                        //A -> C
                        //A -> D
                        //B -> C
                        //B -> D
                        //C -> D
                        for (int i = 0; i < 3; i++)
                        {
                            //Get value using GetProperty() so that a string can be inputted and trendProperties to prevent hard coding
                            string firstValue = (string)targetMovie.GetType().GetProperty(trendProperties[i]).GetValue(targetMovie, null);

                            //Offset prevents hitting the same field for both
                            for (int j = i + 1; j < 4; j++)
                            {
                                //Get second value with the same way
                                string secondValue = (string)targetMovie.GetType().GetProperty(trendProperties[j]).GetValue(targetMovie, null);

                                //Check for empty values beforehand
                                if (firstValue.Trim().IsWhiteSpace() || secondValue.Trim().IsWhiteSpace())
                                {
                                    continue;
                                }

                                //Checks for cast members and genres as they have multiple values

                                //firstValue is a set and secondValue is not a set
                                if (firstValue.Split(", ").Length > 1 && secondValue.Split(", ").Length <= 1)
                                {
                                    string[] splitFirst = firstValue.Split(", ");

                                    foreach (string splitFirstValue in splitFirst)
                                    {
                                        //Append all first values to secondValue
                                        trendCount[trendFields[i] + " + " + trendFields[j]].Add(splitFirstValue + " & " + secondValue);
                                    }

                                    //Continue to prevent wasted processing
                                    continue;
                                }

                                //firstValue is not a set and secondValue is a set
                                if (firstValue.Split(", ").Length <= 1 && secondValue.Split(", ").Length > 1)
                                {
                                    string[] splitSecond = secondValue.Split(", ");

                                    foreach (string splitSecondValue in splitSecond)
                                    {
                                        //Append all second values to firstValue
                                        trendCount[trendFields[i] + " + " + trendFields[j]].Add(firstValue + " & " + splitSecondValue);
                                    }

                                    continue;
                                }

                                //Both values are a set
                                if (firstValue.Split(", ").Length > 1 && secondValue.Split(", ").Length > 1)
                                {
                                    string[] splitFirst = firstValue.Split(", ");
                                    string[] splitSecond = secondValue.Split(", ");

                                    foreach (string splitFirstValue in splitFirst)
                                    {
                                        foreach (string splitSecondValue in splitSecond)
                                        {
                                            //Append to each other to cover all possible combinations
                                            trendCount[trendFields[i] + " + " + trendFields[j]].Add(splitFirstValue + " & " + splitSecondValue);
                                        }
                                    }

                                    continue;
                                }

                                //Neither values are a set
                                if (firstValue.Split(", ").Length <= 1 && secondValue.Split(", ").Length <= 1)
                                {
                                    //Append base values
                                    trendCount[trendFields[i] + " + " + trendFields[j]].Add(firstValue + " & " + secondValue);
                                }
                            }
                        }
                    }
                }
            }

            //Loop through dictionary with KeyValuePair to duplicate it and to get most trending data
            foreach(KeyValuePair<string, List<string>> entry in trendCount)
            {
                returnTable[entry.Key] = entry.Value.GroupBy(x => x) //Groups values into one
                          .OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault(); //Orders by count, then select based off the key name then return first which returns the top result
            }

            //After assignment the table is filled
            return returnTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAmountNum">The amount of users to create</param>
        /// <param name="movieAmountNum">The amount of movies for each</param>
        /// <param name="oldestYearNum">The oldest year they could've watched movies</param>
        /// <returns></returns>
        public bool createDummies(int userAmountNum, int movieAmountNum, int oldestYearNum)
        {
            //Get a copy of all Movie
            List<Movie> movieList = requestMovies();

            //Get the min by subtracting the current by the month to get a past date
            DateOnly dayNumberMin = DateOnly.FromDateTime(DateTime.Now).AddMonths(-(oldestYearNum));
            DateOnly dayNumberMax = DateOnly.FromDateTime(DateTime.Now);

            //Loop through specified amount
            for (int i = 0; i < userAmountNum; i++)
            {
                //StringBuilder as appending will be faster
                StringBuilder sb = new StringBuilder();

                //Special linq query to get random movies that are unique
                //First all duplicates are removed, then it is ordered by a Random value to "shuffle" the list
                //Then it takes the amount of movies specified off the top before being converted to a list
                List<Movie> chosenMovies = movieList.Distinct().OrderBy(_ => Random.Shared.Next()).Take(movieAmountNum).ToList();

                //Loop through each movie
                foreach (Movie movie in chosenMovies)
                {
                    //Check if the min date is lower than the movie, cant see a movie thats not out
                    if (movie.getDate() != null && movie.getDate() > dayNumberMin)
                    {
                        //This is showing an warning but even when I used movie != null, it still appeared making me think it something else
                        DateOnly dateCheck = (DateOnly)movie.getDate();

                        //Get a random day number betweene the min and max
                        DateOnly selectedDate = DateOnly.FromDayNumber(Random.Shared.Next(dateCheck.DayNumber, dayNumberMax.DayNumber + 1));

                        //Convert it into the standard string format "s1&2026-11-20"
                        sb.Append(movie.movieID + "&" + selectedDate.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        //If its not lower then proceed as normal
                        DateOnly selectedDate = DateOnly.FromDayNumber(Random.Shared.Next(dayNumberMin.DayNumber, dayNumberMax.DayNumber + 1));
                        sb.Append(movie.movieID + "&" + selectedDate.ToString("yyyy-MM-dd"));
                    }

                    //Append divider at end
                    sb.Append('|');
                }

                //Remove last divider to clean up
                sb.Remove(sb.Length - 1, 1);

                //Check if the user is created succesfully using a Guid to drastiaclly reduce chance of duplicates
                bool check = createUser(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), sb.ToString());

                //If its fails then cancel the operation
                if (check == false)
                {
                    return false;
                }
            }

            //Else return true
            return true;
        }
    }
}
