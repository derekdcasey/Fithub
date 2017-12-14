namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "MuscleGroup", c => c.String());
            AddColumn("dbo.WorkoutPlans", "Level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutPlans", "Level");
            DropColumn("dbo.Exercises", "MuscleGroup");
        }
    }
}
