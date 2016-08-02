using System.ComponentModel.DataAnnotations;

namespace Zaklady.ViewModels
{
    public class BetViewModel
    {
       
        public int BetId { get; set; }

        
        public int MatchId { get; set; }

     
        public string UserId { get; set; }

        [Required]
        public int HomeTeamBetGoals { get; set; }

        [Required]
        public int AwayTeamBetGoals { get; set; }

        public string HomeTeam { get; set; }
        
        public string AwayTeam { get; set; }
    }
}