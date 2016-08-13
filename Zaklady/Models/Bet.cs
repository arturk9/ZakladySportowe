using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zaklady.Models
{
    public class Bet
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        public int HomeTeamBetGoals { get; set; }

        [Required]
        public int AwayTeamBetGoals { get; set; }

        public int Points { get; set; }

        [Key]
        public int BetId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchId;

        public virtual FootballMatch Match { get; set; }
    }
}