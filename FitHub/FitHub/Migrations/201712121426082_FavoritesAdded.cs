namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFavorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkoutPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFavorites");
        }
    }
}
