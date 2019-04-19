namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migemployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(maxLength: 10),
                        FullName = c.String(),
                        NickName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Employees");
        }
    }
}
