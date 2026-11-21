using Lab_4.Objects;

namespace Lab_4
{
    internal class Client
    {
        static private User? currentUser = null;
        static private List<Movie>? allMovies = null;
        static private DatabaseManager manager = new DatabaseManager();

        static public void addWatchedMovie(string id)
        {
            if (currentUser != null)
            {
                currentUser.watchedMovies = currentUser.watchedMovies + "|" + id + "&" + DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            }
        }

        static public List<Movie>? displayMovies()
        {
            return allMovies;
        }

        static public List<Movie> displayMovies(Filter filter)
        {
            if (allMovies == null || currentUser == null)
            {
                return new List<Movie>();
            }

            List<Movie> movies = new List<Movie>();

            foreach (Movie movie in allMovies)
            {
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

                movies.Add(movie);
            }

            return movies;
        }

        static public List<Movie> getRecomendations()
        {
            List<Movie> returnMovies = new List<Movie>();

            Dictionary<string, List<string>> countDictonary = new()
            {
                ["Genre"] = [],
                ["CastMember"] = []
            };

            if (currentUser != null && allMovies != null)
            {
                string[] movieSets = currentUser.getWatchedMovies().Split("|");

                if (movieSets.Count() <= 0 || movieSets[0].IsWhiteSpace())
                {
                    return returnMovies;
                }

                foreach (string movieSet in movieSets)
                {
                    string movie = movieSet.Split("&")[0];

                    Movie targetMovie = allMovies.Where(m => m.movieID == movie).ToList()[0];

                    //Count the genre, director, and type then return highly rated ones of each

                    //Genres counter
                    string[] listedGenres = targetMovie.listedIn.Split(", ");

                    foreach (string genre in listedGenres)
                    {
                        if (!genre.Trim().IsWhiteSpace())
                        {
                            countDictonary["Genre"].Add(genre);
                        }
                    }

                    //Cast counter

                    string[] listedCast = targetMovie.castMembers.Split(", ");

                    foreach (string castMember in listedCast)
                    {
                        if (!castMember.Trim().IsWhiteSpace())
                        {
                            countDictonary["CastMember"].Add(castMember);
                        }
                    }
                }

                List<string> mostPopularGenre = countDictonary["Genre"].GroupBy(x => x)
                          .OrderByDescending(x => x.Count())
                          .Take(2).Select(x => x.Key).ToList();

                List<string> mostPopularCast = countDictonary["CastMember"].GroupBy(x => x)
                          .OrderByDescending(x => x.Count())
                          .Take(8).Select(x => x.Key).ToList();

                returnMovies = allMovies.Where(m => mostPopularCast.Any(m.castMembers.Contains) && mostPopularGenre.Any(m.listedIn.Contains)).ToList();

                return returnMovies.Distinct().ToList();
            } else
            {
                return returnMovies;
            }
        }

        static public User? getCurrentUser()
        {
            return currentUser;
        }

        static public bool clientLogin(string userName, string password)
        {
            currentUser = manager.serverLogin(userName, password);

            if (currentUser != null)
            {
                allMovies = manager.requestMovies();

                Form.ActiveForm?.Close();
                new ClientDashboard().Show();

                return true;
            } else
            {
                return false;
            }
        }

        static public bool logout()
        {
            currentUser = null;
            allMovies = null;

            Form.ActiveForm?.Close();
            new Login().Show();

            //Yields until logout is complete
            return true;
        }
    }
}