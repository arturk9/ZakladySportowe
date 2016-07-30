using System;
using System.ComponentModel.DataAnnotations;

namespace Zaklady.ViewModels
{
    public class FootballMatchViewModel
    {
        [Required]
        public string Torunament { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public int id { get; set; }

        public string Action
        {
            get { return (id != 0) ? "UpdateFootballMatch" : "CreateFootballMatch"; }
        }

        public string Heading { get; set; }
    }
}