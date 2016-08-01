namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMatchResultsId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FootballMatchResults");
            AlterColumn("dbo.FootballMatchResults", "MatchResultId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FootballMatchResults", "MatchResultId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FootballMatchResults");
            AlterColumn("dbo.FootballMatchResults", "MatchResultId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FootballMatchResults", new[] { "MatchResultId", "MatchId", "UserId" });
        }
    }
}
