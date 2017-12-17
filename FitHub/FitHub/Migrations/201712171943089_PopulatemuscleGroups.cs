namespace FitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatemuscleGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MuscleGroups VALUES('Chest')");
            Sql("INSERT INTO MuscleGroups VALUES('Back')");
            Sql("INSERT INTO MuscleGroups VALUES('Legs')");
            Sql("INSERT INTO MuscleGroups VALUES('Shoulders')");
        }
        
        public override void Down()
        {
        }
    }
}
