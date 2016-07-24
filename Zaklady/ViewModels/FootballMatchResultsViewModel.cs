using System.ComponentModel.DataAnnotations;

namespace Zaklady.ViewModels
{
    public class FootballMatchResultsViewModel
    {
        public int id { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public int PointsForBetingExactTeamScores { get; set; }

        [Required]
        public int PointsForBetingMatchResult { get; set; }

        public string Action
        {
            get { return (id != 0) ? "UpdateFootballMatch" : "CreateFootballMatch"; }
        }

        public string Heading { get; set; }
    }
}