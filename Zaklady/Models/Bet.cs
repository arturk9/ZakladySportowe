using System.ComponentModel.DataAnnotations;

namespace Zaklady.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int HomeTeamBetGoals { get; set; }

        [Required]
        public int AwayTeamBetGoals { get; set; }

        public int Points { get; set; }

        public virtual FootballMatch FootballMatch { get; set; }
    }
}