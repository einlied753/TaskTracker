namespace TaskTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        ProjectId = c.Int(),
                        Description = c.String(),
                        Status = c.Byte(nullable: false),
                        Priority = c.Int(nullable: false),
                        Role = c.Byte(nullable: false),
                        AssigneeId = c.Int(),
                        ReporterId = c.Int(),
                        AnalystId = c.Int(),
                        DeveloperId = c.Int(),
                        TesterId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AnalystId)
                .ForeignKey("dbo.Users", t => t.AssigneeId)
                .ForeignKey("dbo.Users", t => t.DeveloperId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.ReporterId)
                .ForeignKey("dbo.Users", t => t.TesterId)
                .Index(t => t.ProjectId)
                .Index(t => t.AssigneeId)
                .Index(t => t.ReporterId)
                .Index(t => t.AnalystId)
                .Index(t => t.DeveloperId)
                .Index(t => t.TesterId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Position = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        CompletitionDate = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                        Priority = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TesterId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "ReporterId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "DeveloperId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssigneeId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AnalystId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "TesterId" });
            DropIndex("dbo.Tasks", new[] { "DeveloperId" });
            DropIndex("dbo.Tasks", new[] { "AnalystId" });
            DropIndex("dbo.Tasks", new[] { "ReporterId" });
            DropIndex("dbo.Tasks", new[] { "AssigneeId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
