using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Objects
{
    public class Admin : User
    {
        public Admin(int userID, string username, DateTime lastActive, List<UserMovie> watchedMovies) : base(userID, username, lastActive, watchedMovies)
        {
        }

        public List<User> createDummyAccounts(int amount, int watchAmount)
        {
            return new List<User>();
        }
    }
}
