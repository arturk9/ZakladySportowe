namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingPointsFromBetModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bets", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bets", "Points", c => c.Int(nullable: false));
        }
    }
}
