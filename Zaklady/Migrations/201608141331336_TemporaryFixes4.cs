namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemporaryFixes4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "UserId" });
            RenameColumn(table: "dbo.Bets", name: "Match_Id", newName: "MatchId");
            RenameIndex(table: "dbo.Bets", name: "IX_Match_Id", newName: "IX_MatchId");
            AlterColumn("dbo.Bets", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bets", "UserId");
            AddForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "UserId" });
            AlterColumn("dbo.Bets", "UserId", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.Bets", name: "IX_MatchId", newName: "IX_Match_Id");
            RenameColumn(table: "dbo.Bets", name: "MatchId", newName: "Match_Id");
            CreateIndex("dbo.Bets", "UserId");
            AddForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
