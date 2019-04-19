namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsectionnmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionCode = c.String(maxLength: 10),
                        SectionName = c.String(maxLength: 150),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depts", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "DeptId", "dbo.Depts");
            DropIndex("dbo.Sections", new[] { "DeptId" });
            DropTable("dbo.Sections");
        }
    }
}
