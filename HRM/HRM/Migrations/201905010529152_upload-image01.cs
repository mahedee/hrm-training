namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploadimage01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeePhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeePhotoPath");
        }
    }
}
