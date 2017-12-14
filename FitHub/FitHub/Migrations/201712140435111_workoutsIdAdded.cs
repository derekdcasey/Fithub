namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutsIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutPlans", "WorkoutId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutPlans", "WorkoutId");
        }
    }
}
