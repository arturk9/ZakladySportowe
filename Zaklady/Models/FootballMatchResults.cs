using System.ComponentModel.DataAnnotations;

namespace Zaklady.Models
{
    public class FootballMatchResults
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public int PointsForBetingExactTeamScores { get; set; }

        [Required]
        public int PointsForBetingMatchResult { get; set; }
    }
}