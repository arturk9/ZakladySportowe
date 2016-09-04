using System.Collections.Generic;
using Zaklady.Models;

namespace Zaklady.ViewModels
{
    public class UsersViewModel
    {
        public List<ApplicationUser> UsersList;

        public void SetUsersPoints(IEnumerable<ApplicationUser> UsersList, IEnumerable<Bet> BetsList)
        {
            foreach (var user in UsersList)
            {
                user.UserPoints = 0;

                foreach (var bet in BetsList)
                {
                    if (user.Id == bet.UserId)
                    {
                        user.UserPoints += bet.Points;
                    }
                }
            }
        }
    }
}