namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResultparameter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluations", "Result", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evaluations", "Result");
        }
    }
}
