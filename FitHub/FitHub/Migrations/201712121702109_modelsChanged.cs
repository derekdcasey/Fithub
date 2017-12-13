namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutPlans", "Title", c => c.String());
            AddColumn("dbo.WorkoutPlans", "Description", c => c.String());
            AddColumn("dbo.WorkoutPlans", "WorkoutId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkoutPlans", "NumberOfDays", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "DayNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Workouts", "ExerciseId");
            AddForeignKey("dbo.Workouts", "ExerciseId", "dbo.Exercises", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.Workouts", new[] { "ExerciseId" });
            DropColumn("dbo.Workouts", "DayNumber");
            DropColumn("dbo.WorkoutPlans", "NumberOfDays");
            DropColumn("dbo.WorkoutPlans", "WorkoutId");
            DropColumn("dbo.WorkoutPlans", "Description");
            DropColumn("dbo.WorkoutPlans", "Title");
        }
    }
}
