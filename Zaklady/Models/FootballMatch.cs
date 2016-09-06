using System;
using System.Collections.Generic;

namespace Zaklady.Models
{
    public class FootballMatch
    {
        public int Id { get; set; }        

        public string UserId { get; set; }

        public string TorunamentName { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime DateTime { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int PointsForBettingExactTeamScores { get; set; }

        public int PointsForBettingCorrectMatchResult { get; set; }


        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}