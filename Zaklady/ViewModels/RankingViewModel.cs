using System.Linq;
using Zaklady.Models;

namespace Zaklady.ViewModels
{
    public class RankingViewModel
    {
        private readonly ApplicationDbContext _context;

        public void assignPoints()
        {
            foreach (var user in _context.Users)
                foreach (var footballMatch in _context.FootballMatches)
                    foreach (var bet in _context.Bets.Where(m => m.User == user).Where(m => m.BetId == footballMatch.Id))
                    {
                        if (bet.HomeTeamBetGoals == footballMatch.HomeTeamGoals && bet.AwayTeamBetGoals == footballMatch.AwayTeamGoals)
                            user.UserPoints += footballMatch.PointsForBetingExactTeamScores;
                        _context.SaveChanges();
                    }

        }



    }
}