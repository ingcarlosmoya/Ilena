namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patients : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Evaluations", "PatientId");
            AddForeignKey("dbo.Evaluations", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "PatientId", "dbo.Patients");
            DropIndex("dbo.Evaluations", new[] { "PatientId" });
        }
    }
}
