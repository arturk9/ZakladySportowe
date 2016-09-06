using System;
using System.ComponentModel.DataAnnotations;

namespace Zaklady.ViewModels
{
    public class FootballMatchViewModel
    {
        [Required]
        public string TorunamentName { get; set; }

        [Required]
        public string HomeTeamName { get; set; }

        [Required]
        public string AwayTeamName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public int Id { get; set; }

        public string Action
        {
            get { return (Id != 0) ? "UpdateFootballMatchDatabaseRecord" : "InsertFootballMatchRecord"; }
        }

        public string Heading { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public int PointsForBettingExactTeamScores { get; set; }

        [Required]
        public int PointsForBettingCorrectMatchResult { get; set; }
    }
}