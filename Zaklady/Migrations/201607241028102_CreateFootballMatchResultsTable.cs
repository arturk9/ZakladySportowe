namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFootballMatchResultsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FootballMatchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        HomeTeam = c.String(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        PointsForBetingExactTeamScores = c.Int(nullable: false),
                        PointsForBetingMatchResult = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballMatchResults", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatchResults", new[] { "UserId" });
            DropTable("dbo.FootballMatchResults");
        }
    }
}
