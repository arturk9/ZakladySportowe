namespace Zaklady.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPointsToBetModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bets", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bets", "Points");
        }
    }
}
