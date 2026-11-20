using Lab_4.Objects;

namespace Lab_4
{
    internal class Client
    {
        static private User? currentUser = null;
        static private List<Movie>? allMovies = null;

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
            if (allMovies == null)
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

        static public User? getCurrentUser()
        {
            return currentUser;
        }

        static public bool clientLogin(string userName, string password)
        {
            currentUser = DatabaseManager.serverLogin(userName, password);

            if (currentUser != null)
            {
                allMovies = DatabaseManager.requestMovies();

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