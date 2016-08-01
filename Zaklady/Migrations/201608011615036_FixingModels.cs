namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FootballMatchResults", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatchResults", new[] { "UserId" });
            AddColumn("dbo.FootballMatches", "HomeTeamGoals", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "AwayTeamGoals", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "PointsForBetingExactTeamScores", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatches", "PointsForBetingMatchResult", c => c.Int(nullable: false));
            DropTable("dbo.FootballMatchResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FootballMatchResults",
                c => new
                    {
                        MatchResultId = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        HomeTeam = c.String(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        PointsForBetingExactTeamScores = c.Int(nullable: false),
                        PointsForBetingMatchResult = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchResultId);
            
            DropColumn("dbo.FootballMatches", "PointsForBetingMatchResult");
            DropColumn("dbo.FootballMatches", "PointsForBetingExactTeamScores");
            DropColumn("dbo.FootballMatches", "AwayTeamGoals");
            DropColumn("dbo.FootballMatches", "HomeTeamGoals");
            CreateIndex("dbo.FootballMatchResults", "UserId");
            AddForeignKey("dbo.FootballMatchResults", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
