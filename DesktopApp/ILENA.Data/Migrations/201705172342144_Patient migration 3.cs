namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patientmigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Sporter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "WhichSport", c => c.String());
            AddColumn("dbo.Patients", "SeatedHours", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "ActiveBreaksAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ActiveBreaksAmount");
            DropColumn("dbo.Patients", "SeatedHours");
            DropColumn("dbo.Patients", "WhichSport");
            DropColumn("dbo.Patients", "Sporter");
        }
    }
}
