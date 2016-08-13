using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zaklady.Models
{
    public class FootballMatch
    {
        public int Id { get; set; }        

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Torunament { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public int PointsForBetingExactTeamScores { get; set; }

        [Required]
        public int PointsForBetingMatchResult { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public ApplicationUser User { get; set; }
    }
}