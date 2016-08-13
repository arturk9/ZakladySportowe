namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBetsFootballMatchNameProperty : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bets", name: "FootballMatch_Id", newName: "Match_Id");
            RenameIndex(table: "dbo.Bets", name: "IX_FootballMatch_Id", newName: "IX_Match_Id");
            DropColumn("dbo.Bets", "MatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bets", "MatchId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Bets", name: "IX_Match_Id", newName: "IX_FootballMatch_Id");
            RenameColumn(table: "dbo.Bets", name: "Match_Id", newName: "FootballMatch_Id");
        }
    }
}
