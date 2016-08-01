namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddigBet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        BetId = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        UserId = c.String(nullable: false),
                        HomeTeamBetGoals = c.Int(nullable: false),
                        AwayTeamBetGoals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bets");
        }
    }
}
