namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClockInTime = c.DateTime(),
                        ClockOutTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        NID = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserType = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropTable("dbo.Notices");
            DropTable("dbo.Employees");
            DropTable("dbo.Attendances");
        }
    }
}
