namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringPropertiesNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "BetHomeTeamGoals", c => c.Int(nullable: false));
            AddColumn("dbo.Bets", "BetAwayTeamGoals", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "TorunamentName", c => c.String());
            AddColumn("dbo.FootballMatches", "HomeTeamName", c => c.String());
            AddColumn("dbo.FootballMatches", "AwayTeamName", c => c.String());
            AddColumn("dbo.FootballMatches", "PointsForBettingExactTeamScores", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "PointsForBettingCorrectMatchResult", c => c.Int(nullable: false));
            DropColumn("dbo.Bets", "HomeTeamBetGoals");
            DropColumn("dbo.Bets", "AwayTeamBetGoals");
            DropColumn("dbo.FootballMatches", "Torunament");
            DropColumn("dbo.FootballMatches", "HomeTeam");
            DropColumn("dbo.FootballMatches", "AwayTeam");
            DropColumn("dbo.FootballMatches", "PointsForBetingExactTeamScores");
            DropColumn("dbo.FootballMatches", "PointsForBetingMatchResult");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballMatches", "PointsForBetingMatchResult", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "PointsForBetingExactTeamScores", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "AwayTeam", c => c.String());
            AddColumn("dbo.FootballMatches", "HomeTeam", c => c.String());
            AddColumn("dbo.FootballMatches", "Torunament", c => c.String());
            AddColumn("dbo.Bets", "AwayTeamBetGoals", c => c.Int(nullable: false));
            AddColumn("dbo.Bets", "HomeTeamBetGoals", c => c.Int(nullable: false));
            DropColumn("dbo.FootballMatches", "PointsForBettingCorrectMatchResult");
            DropColumn("dbo.FootballMatches", "PointsForBettingExactTeamScores");
            DropColumn("dbo.FootballMatches", "AwayTeamName");
            DropColumn("dbo.FootballMatches", "HomeTeamName");
            DropColumn("dbo.FootballMatches", "TorunamentName");
            DropColumn("dbo.Bets", "BetAwayTeamGoals");
            DropColumn("dbo.Bets", "BetHomeTeamGoals");
        }
    }
}
