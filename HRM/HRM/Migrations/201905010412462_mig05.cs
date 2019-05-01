namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MobileNumber", c => c.String(maxLength: 15));
            AddColumn("dbo.Employees", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Employees", "BloodGroup", c => c.String(maxLength: 3));
            AddColumn("dbo.Employees", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String());
            CreateIndex("dbo.Employees", "DeptId");
            AddForeignKey("dbo.Employees", "DeptId", "dbo.Depts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Depts");
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "DeptId");
            DropColumn("dbo.Employees", "BloodGroup");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "MobileNumber");
        }
    }
}
