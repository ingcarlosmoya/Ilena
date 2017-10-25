namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movements", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routines", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "CreateDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "CreateDateTime");
            DropColumn("dbo.Routines", "CreateDateTime");
            DropColumn("dbo.Movements", "CreateDateTime");
        }
    }
}
