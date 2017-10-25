namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patientmigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        LastName = c.String(),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Routines", "PatientId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routines", "PatientId");
            DropTable("dbo.Patients");
        }
    }
}
