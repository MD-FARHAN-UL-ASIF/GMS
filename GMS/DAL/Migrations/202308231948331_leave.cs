namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveType = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        TotalAnnualLeaveEntitlement = c.Int(nullable: false),
                        RemainingLeave = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropTable("dbo.Leaves");
        }
    }
}
