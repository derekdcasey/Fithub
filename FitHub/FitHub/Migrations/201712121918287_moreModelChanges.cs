namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkoutPlans", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.WorkoutPlans", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkoutPlans", "Description", c => c.String());
            AlterColumn("dbo.WorkoutPlans", "Title", c => c.String());
        }
    }
}
