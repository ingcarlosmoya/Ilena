namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "SleepHours", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Backache", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "Neckache", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "Shoulderache", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "Handsache", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Handsache");
            DropColumn("dbo.Patients", "Shoulderache");
            DropColumn("dbo.Patients", "Neckache");
            DropColumn("dbo.Patients", "Backache");
            DropColumn("dbo.Patients", "SleepHours");
        }
    }
}
