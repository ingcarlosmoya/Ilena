namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyEvaluation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluations", "Mean", c => c.Double(nullable: false));
            AddColumn("dbo.Evaluations", "Median", c => c.Double(nullable: false));
            AddColumn("dbo.Evaluations", "Mode", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evaluations", "Mode");
            DropColumn("dbo.Evaluations", "Median");
            DropColumn("dbo.Evaluations", "Mean");
        }
    }
}
