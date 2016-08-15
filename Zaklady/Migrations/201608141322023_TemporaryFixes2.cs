namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemporaryFixes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bets", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Bets", "UserId");
            AddForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bets", new[] { "UserId" });
            AlterColumn("dbo.Bets", "UserId", c => c.String(nullable: false));
        }
    }
}
