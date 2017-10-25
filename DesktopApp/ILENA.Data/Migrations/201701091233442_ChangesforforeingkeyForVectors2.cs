namespace ILENA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesforforeingkeyForVectors2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoutineId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routines", t => t.RoutineId, cascadeDelete: true)
                .Index(t => t.RoutineId);
            
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vectors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Joint = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Z = c.Double(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        MovementId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movements", t => t.MovementId, cascadeDelete: true)
                .Index(t => t.MovementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vectors", "MovementId", "dbo.Movements");
            DropForeignKey("dbo.Movements", "RoutineId", "dbo.Routines");
            DropIndex("dbo.Vectors", new[] { "MovementId" });
            DropIndex("dbo.Movements", new[] { "RoutineId" });
            DropTable("dbo.Vectors");
            DropTable("dbo.Routines");
            DropTable("dbo.Movements");
        }
    }
}
