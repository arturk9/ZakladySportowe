namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMatchResultsTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FootballMatchResults");
            AddPrimaryKey("dbo.FootballMatchResults", new[] { "MatchResultId", "MatchId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FootballMatchResults");
            AddPrimaryKey("dbo.FootballMatchResults", new[] { "MatchId", "UserId" });
        }
    }
}
