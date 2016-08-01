namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FootballMatchResults");
            AddColumn("dbo.AspNetUsers", "UserPoints", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatchResults", "MatchId", c => c.Int(nullable: false));
            AddColumn("dbo.FootballMatchResults", "MatchResultId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FootballMatchResults", new[] { "MatchId", "UserId" });
            DropColumn("dbo.FootballMatchResults", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FootballMatchResults", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.FootballMatchResults");
            DropColumn("dbo.FootballMatchResults", "MatchResultId");
            DropColumn("dbo.FootballMatchResults", "MatchId");
            DropColumn("dbo.AspNetUsers", "UserPoints");
            AddPrimaryKey("dbo.FootballMatchResults", "Id");
        }
    }
}
