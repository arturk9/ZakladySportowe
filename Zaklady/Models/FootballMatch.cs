using System;
using System.ComponentModel.DataAnnotations;

namespace Zaklady.Models
{
    public class FootballMatch
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set;}

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
    }
}