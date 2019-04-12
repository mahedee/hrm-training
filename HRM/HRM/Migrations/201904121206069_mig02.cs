namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptCode = c.String(),
                        DeptName = c.String(),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Depts", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Depts", new[] { "DivisionId" });
            DropTable("dbo.Depts");
        }
    }
}
