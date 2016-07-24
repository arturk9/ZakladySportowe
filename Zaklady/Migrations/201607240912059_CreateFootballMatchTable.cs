namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFootballMatchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FootballMatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Torunament = c.String(nullable: false),
                        HomeTeam = c.String(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballMatches", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FootballMatches", new[] { "User_Id" });
            DropTable("dbo.FootballMatches");
        }
    }
}
