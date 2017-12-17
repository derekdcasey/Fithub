namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Exercises", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Exercises", "MuscleGroup", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Exercises", "ImagePath", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "ImagePath", c => c.String());
            AlterColumn("dbo.Exercises", "MuscleGroup", c => c.String());
            AlterColumn("dbo.Exercises", "Description", c => c.String());
            AlterColumn("dbo.Exercises", "Name", c => c.String());
        }
    }
}
