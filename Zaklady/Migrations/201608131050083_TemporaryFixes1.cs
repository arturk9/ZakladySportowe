namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemporaryFixes1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FootballMatches", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatches", new[] { "UserId" });
            AlterColumn("dbo.FootballMatches", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FootballMatches", "Torunament", c => c.String());
            AlterColumn("dbo.FootballMatches", "HomeTeam", c => c.String());
            AlterColumn("dbo.FootballMatches", "AwayTeam", c => c.String());
            CreateIndex("dbo.FootballMatches", "UserId");
            AddForeignKey("dbo.FootballMatches", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballMatches", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatches", new[] { "UserId" });
            AlterColumn("dbo.FootballMatches", "AwayTeam", c => c.String(nullable: false));
            AlterColumn("dbo.FootballMatches", "HomeTeam", c => c.String(nullable: false));
            AlterColumn("dbo.FootballMatches", "Torunament", c => c.String(nullable: false));
            AlterColumn("dbo.FootballMatches", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.FootballMatches", "UserId");
            AddForeignKey("dbo.FootballMatches", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
