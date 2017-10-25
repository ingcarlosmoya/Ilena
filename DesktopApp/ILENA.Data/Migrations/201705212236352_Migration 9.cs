namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluations", "Pain", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Evaluations", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Evaluations", "CategoryName", c => c.Int(nullable: false));
            DropColumn("dbo.Evaluations", "Pain");
        }
    }
}
