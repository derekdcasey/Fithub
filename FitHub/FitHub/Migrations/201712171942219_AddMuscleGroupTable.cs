namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMuscleGroupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MuscleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exercises", "MuscleGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercises", "MuscleGroup", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "MuscleGroup", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Exercises", "MuscleGroupId");
            DropTable("dbo.MuscleGroups");
        }
    }
}
