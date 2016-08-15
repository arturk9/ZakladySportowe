using System;
using System.Collections.Generic;

namespace Zaklady.Models
{
    public class FootballMatch
    {
        public int Id { get; set; }        

        public string UserId { get; set; }

        public string Torunament { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime DateTime { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int PointsForBetingExactTeamScores { get; set; }

        public int PointsForBetingMatchResult { get; set; }


        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}