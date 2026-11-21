using Lab_4.Forms;
using Lab_4.Objects;
using System.Runtime.CompilerServices;

namespace Lab_4
{
    /// <summary>
    /// The main connector between the user and server.
    /// </summary>
    internal class Client
    {
        /// <value>Property <c>currentUser</c> represents the currently logged in user or null if none are logged in</value>
        static private User? currentUser = null;
        /// <value>Property <c>allMovies</c> represents the storage of all movies on the client to increase search speeds and reduce
        /// back and forth between the files and client</value>
        static private List<Movie>? allMovies = null;
        /// <value>Property <c>manager</c> represents the connection to the database through a connection rather than direct access</value>
        static private DatabaseManager manager = new DatabaseManager();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Starts the custom AppContext
            AppContext.Current.ShowForm(new Login());
            Application.Run(AppContext.Current);
        }

        /// <summary>
        /// Adds the target movie ID to the end of the user's watched movies.
        /// </summary>
        /// <param name="id">The target movie ID</param>
        static public void addWatchedMovie(string id)
        {
            if (currentUser != null)
            {
                //Add to end of watchedMovies
                currentUser.watchedMovies = currentUser.watchedMovies + "|" + id + "&" + DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Returns the entire Movie list to display on login
        /// </summary>
        /// <returns>The entire Movie list</returns>
        static public List<Movie>? displayMovies()
        {
            return allMovies;
        }

        /// <summary>
        /// Takes in a Filter object and returns a list of Movie based on it to display
        /// </summary>
        /// <param name="filter">What filters to apply</param>
        /// <returns>A list of Movie that are filtered by the User</returns>
        static public List<Movie> displayMovies(Filter filter)
        {
            //Check if either is null then return an empty list back as nothing is saved yet
            if (allMovies == null || currentUser == null)
            {
                return new List<Movie>();
            }
            
            //Create the return list
            List<Movie> movies = new List<Movie>();

            //Loop through all the movies
            foreach (Movie movie in allMovies)
            {
                //Check if a filter isnt null and that the target contains the specified filter, if it doesnt then it is discarded
                //by continuing to the next loop until it is empty
                if (filter.keyword != null && !movie.description.ToLower().Contains(filter.keyword))
                {
                    continue;
                }

                if (filter.title != null && !movie.title.ToLower().Contains(filter.title))
                {
                    continue;
                }

                if (filter.director != null && !movie.director.ToLower().Contains(filter.director))
                {
                    continue;
                }

                if (filter.releaseYear != null && !(movie.dateReleased == filter.releaseYear))
                {
                    continue;
                }

                if (filter.genre != null && !movie.listedIn.ToLower().Contains(filter.genre))
                {
                    continue;
                }

                //If it doesn't get bounced then it meets all critera and should be added
                movies.Add(movie);
            }

            //Return the new filtered list
            return movies;
        }

        /// <summary>
        /// Returns a set of recomendded movies by getting all movies with the top 8 most watched cast members within the 2 most watched genres,
        /// this returns a good range of recomendations roughly around 50.
        /// </summary>
        /// <returns>Curated Movie list</returns>
        static public List<Movie> getRecomendations()
        {
            //Create return list
            List<Movie> returnMovies = new List<Movie>();

            //Create dictonary to store duplicates as thats how the top amount are determined
            Dictionary<string, List<string>> countDictonary = new()
            {
                ["Genre"] = [],
                ["CastMember"] = []
            };

            //Check if all movies are here and user is logged in
            if (currentUser != null && allMovies != null)
            {
                //Split watched movie to get each movie
                string[] movieSets = currentUser.getWatchedMovies().Split("|");

                //If a User has no movies return an empty list
                if (movieSets.Count() <= 0 || movieSets[0].IsWhiteSpace())
                {
                    return returnMovies;
                }

                //Loop through each string
                foreach (string movieSet in movieSets)
                {
                    //Returns the movie ID
                    string movie = movieSet.Split("&")[0];

                    //Use linq query on local copy to get Movie object
                    Movie targetMovie = allMovies.Where(m => m.movieID == movie).FirstOrDefault();

                    //Count the genre and cast members then return highly rated ones of each

                    //Genres counter
                    string[] listedGenres = targetMovie.listedIn.Split(", ");

                    foreach (string genre in listedGenres)
                    {
                        //Check for whitespace
                        if (!genre.Trim().IsWhiteSpace())
                        {
                            //Add copy to List as a list can hold duplicates
                            countDictonary["Genre"].Add(genre);
                        }
                    }

                    //Repeat for cast members
                    string[] listedCast = targetMovie.castMembers.Split(", ");

                    foreach (string castMember in listedCast)
                    {
                        if (!castMember.Trim().IsWhiteSpace())
                        {
                            countDictonary["CastMember"].Add(castMember);
                        }
                    }
                }

                //Another linq query to sort out the dictionary, first its grouped together into a single group
                List<string> mostPopularGenre = countDictonary["Genre"].GroupBy(x => x)
                          .OrderByDescending(x => x.Count()) //Then its order in descending order based on the count of each group, meaning the most duplicates will be first
                          .Take(2).Select(x => x.Key).ToList(); //Take(2) returns the top 2 of the list in order and select returns the name of the group of duplicates
                                                                //which is the genre before being converted into a list so we can have the top 2 instead of just one

                //Repeat the same process but instead take(8) so its the top 8 cast memebers
                List<string> mostPopularCast = countDictonary["CastMember"].GroupBy(x => x)
                          .OrderByDescending(x => x.Count())
                          .Take(8).Select(x => x.Key).ToList();

                //Get the final result with another linq query using an intersection with List.Any(...) where we check if the movie's castMembers list contains any
                //of the List, in this case the top 8 members. This is then completed with an && to get all results where it contains one of both set of keywords before
                //turning into a list that is usuable.
                returnMovies = allMovies.Where(m => mostPopularCast.Any(m.castMembers.Contains) && mostPopularGenre.Any(m.listedIn.Contains)).ToList();

                //Before returning the .Distinct() ensures no duplicate Movie as two actors could have starred in the same Movie creating a duplicate which
                //is not good for recomendations.
                return returnMovies.Distinct().ToList();
            } else
            {
                return returnMovies;
            }
        }

        /// <summary>
        /// Returns the current User if there is any
        /// </summary>
        /// <returns>A User object or null</returns>
        static public User? getCurrentUser()
        {
            return currentUser;
        }

        /// <summary>
        /// Checks with the server if the credentials are valid before moving to ClientDashboard and being assigned a currentUser.
        /// </summary>
        /// <param name="userName">The username from the text field</param>
        /// <param name="password">The password from the text field</param>
        /// <returns>true if it was validated and false if not</returns>
        static public bool clientLogin(string userName, string password)
        {
            //Check if login was valid
            currentUser = manager.serverLogin(userName, password);

            if (currentUser != null)
            {
                //Request all movies to be able to do filtering locally
                allMovies = manager.requestMovies();

                //We save the old form before switching to ensure we dont destroy the new one
                Form? currentForm = Form.ActiveForm;
                //Update the "head" of the AppContext
                AppContext.Current.ShowForm(new ClientDashboard());
                //Close the old form
                currentForm.Close();

                return true;
            }
            else
            {
                //Return false if not
                return false;
            }
        }

        /// <summary>
        /// Checks if the logged in User is admin or not and switches to AdminDashboard
        /// </summary>
        static public void adminBoardCheck()
        {
            //Check status
            if (currentUser != null && currentUser.getStatus() == true)
            {
                //Change form to AdminDashboard
                Form? currentForm = Form.ActiveForm;
                AppContext.Current.ShowForm(new AdminDashboard());
                currentForm.Close();
            }
        }

        /// <summary>
        /// Returns to ClientDashboard
        /// </summary>
        static public void returnToClientBoard()
        {
            //Change form to ClientDashboard
            Form? currentForm = Form.ActiveForm;
            AppContext.Current.ShowForm(new ClientDashboard());
            currentForm.Close();
        }

        /// <summary>
        /// Logs the user out while yeilding to ensure no additonal inputs are made
        /// </summary>
        /// <returns></returns>
        static public bool logout()
        {
            //Set all login fields to null
            currentUser = null;
            allMovies = null;

            //Change form to login
            Form? currentForm = Form.ActiveForm;
            AppContext.Current.ShowForm(new Login());
            currentForm.Close();

            //Yields until logout is complete
            return true;
        }
    }
}