namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingOneToManyRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "FootballMatch_Id", c => c.Int());
            CreateIndex("dbo.Bets", "FootballMatch_Id");
            AddForeignKey("dbo.Bets", "FootballMatch_Id", "dbo.FootballMatches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "FootballMatch_Id", "dbo.FootballMatches");
            DropIndex("dbo.Bets", new[] { "FootballMatch_Id" });
            DropColumn("dbo.Bets", "FootballMatch_Id");
        }
    }
}
