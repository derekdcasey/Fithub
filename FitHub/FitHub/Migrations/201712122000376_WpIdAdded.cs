namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WpIdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workouts", "WorkoutPlan_Id", "dbo.WorkoutPlans");
            DropIndex("dbo.Workouts", new[] { "WorkoutPlan_Id" });
            RenameColumn(table: "dbo.Workouts", name: "WorkoutPlan_Id", newName: "WorkoutPlanId");
            AlterColumn("dbo.Workouts", "WorkoutPlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workouts", "WorkoutPlanId");
            AddForeignKey("dbo.Workouts", "WorkoutPlanId", "dbo.WorkoutPlans", "Id", cascadeDelete: true);
            DropColumn("dbo.WorkoutPlans", "WorkoutId");
            DropColumn("dbo.WorkoutPlans", "NumberOfDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkoutPlans", "NumberOfDays", c => c.Int(nullable: false));
            AddColumn("dbo.WorkoutPlans", "WorkoutId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Workouts", "WorkoutPlanId", "dbo.WorkoutPlans");
            DropIndex("dbo.Workouts", new[] { "WorkoutPlanId" });
            AlterColumn("dbo.Workouts", "WorkoutPlanId", c => c.Int());
            RenameColumn(table: "dbo.Workouts", name: "WorkoutPlanId", newName: "WorkoutPlan_Id");
            CreateIndex("dbo.Workouts", "WorkoutPlan_Id");
            AddForeignKey("dbo.Workouts", "WorkoutPlan_Id", "dbo.WorkoutPlans", "Id");
        }
    }
}
