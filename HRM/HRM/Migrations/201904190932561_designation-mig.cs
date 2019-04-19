namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class designationmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Designations");
        }
    }
}
