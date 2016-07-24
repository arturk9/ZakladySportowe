namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverridingFootballMatchTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FootballMatches", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatches", new[] { "User_Id" });
            AlterColumn("dbo.FootballMatches", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.FootballMatches", "User_Id");
            AddForeignKey("dbo.FootballMatches", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballMatches", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatches", new[] { "User_Id" });
            AlterColumn("dbo.FootballMatches", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FootballMatches", "User_Id");
            AddForeignKey("dbo.FootballMatches", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
