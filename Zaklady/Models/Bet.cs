using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zaklady.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public string UserId { get; set; }

        [Required]
        public int HomeTeamBetGoals { get; set; }

        [Required]
        public int AwayTeamBetGoals { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? MatchId { get; set; }

        public virtual FootballMatch Match { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}