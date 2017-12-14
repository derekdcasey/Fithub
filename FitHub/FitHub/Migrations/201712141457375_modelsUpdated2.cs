namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsUpdated2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkoutPlans", "WorkoutId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkoutPlans", "WorkoutId", c => c.Int(nullable: false));
        }
    }
}
