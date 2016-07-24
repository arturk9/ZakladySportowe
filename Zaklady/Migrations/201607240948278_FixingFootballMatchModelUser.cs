namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingFootballMatchModelUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FootballMatches", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.FootballMatches", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FootballMatches", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.FootballMatches", name: "UserId", newName: "User_Id");
        }
    }
}
