using System.ComponentModel.DataAnnotations;

namespace Zaklady.ViewModels
{
    public class BetViewModel
    {
       
        public int BetId { get; set; }

        [Required]
        public int MatchId { get; set; }
     
        public string UserId { get; set; }

        [Required]
        public int HomeTeamBetGoals { get; set; }

        [Required]
        public int AwayTeamBetGoals { get; set; }

        public string HomeTeam { get; set; }
        
        public string AwayTeam { get; set; }

        public int id { get; set; }

        public string Action
        {
            get { return (BetId != 0) ? "UpdateBet" : "BetAScore"; }
        }
    }
}