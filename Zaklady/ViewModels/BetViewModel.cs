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
        public int BetHomeTeamGoals { get; set; }

        [Required]
        public int BetAwayTeamGoals { get; set; }

        public string HomeTeamName { get; set; }
        
        public string AwayTeamName { get; set; }

        public int Id { get; set; }

        public string Action
        {
            get { return (BetId != 0) ? "UpdateBetRecord" : "InsertBetRecordToDatabase"; }
        }
    }
}