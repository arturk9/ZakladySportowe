using System.Collections.Generic;
using Zaklady.Models;

namespace Zaklady.ViewModels
{
    public class UsersViewModel
    {
        public List<ApplicationUser> UsersList;

        public void SetUsersPoints(IEnumerable<ApplicationUser> usersList, IEnumerable<Bet> betsList)
        {
            foreach (var user in usersList)
            {
                user.UserPoints = 0;

                foreach (var bet in betsList)
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