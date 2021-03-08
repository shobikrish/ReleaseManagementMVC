namespace ReleaseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        BugID = c.String(nullable: false, maxLength: 128),
                        ModuleID = c.String(maxLength: 128),
                        TesterID = c.String(maxLength: 128),
                        BugStatus = c.String(),
                    })
                .PrimaryKey(t => t.BugID)
                .ForeignKey("dbo.Modules", t => t.ModuleID)
                .ForeignKey("dbo.Testers", t => t.TesterID)
                .Index(t => t.ModuleID)
                .Index(t => t.TesterID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleID = c.String(nullable: false, maxLength: 128),
                        ModuleName = c.String(),
                        ProjectID = c.String(maxLength: 128),
                        ModuleStatus = c.String(),
                        DeveloperID = c.String(maxLength: 128),
                        TesterID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ModuleID)
                .ForeignKey("dbo.Developers", t => t.DeveloperID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Testers", t => t.TesterID)
                .Index(t => t.ProjectID)
                .Index(t => t.DeveloperID)
                .Index(t => t.TesterID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperID = c.String(nullable: false, maxLength: 128),
                        DeveloperName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.String(nullable: false, maxLength: 128),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedEndDate = c.DateTime(nullable: false),
                        ActualEndDate = c.DateTime(nullable: false),
                        TeamID = c.String(maxLength: 128),
                        ProjectStatus = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.String(nullable: false, maxLength: 128),
                        TeamLeadID = c.String(maxLength: 128),
                        IsAvailable = c.String(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.Employees", t => t.TeamLeadID)
                .Index(t => t.TeamLeadID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.String(nullable: false, maxLength: 128),
                        EmpName = c.String(),
                        EmpRole = c.String(),
                    })
                .PrimaryKey(t => t.EmpID)
                .ForeignKey("dbo.Logins", t => t.EmpID)
                .Index(t => t.EmpID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginID);
            
            CreateTable(
                "dbo.Testers",
                c => new
                    {
                        TesterID = c.String(nullable: false, maxLength: 128),
                        TesterName = c.String(),
                        TesterStatus = c.String(),
                    })
                .PrimaryKey(t => t.TesterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "TesterID", "dbo.Testers");
            DropForeignKey("dbo.Bugs", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.Modules", "TesterID", "dbo.Testers");
            DropForeignKey("dbo.Modules", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "TeamLeadID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmpID", "dbo.Logins");
            DropForeignKey("dbo.Modules", "DeveloperID", "dbo.Developers");
            DropIndex("dbo.Employees", new[] { "EmpID" });
            DropIndex("dbo.Teams", new[] { "TeamLeadID" });
            DropIndex("dbo.Projects", new[] { "TeamID" });
            DropIndex("dbo.Modules", new[] { "TesterID" });
            DropIndex("dbo.Modules", new[] { "DeveloperID" });
            DropIndex("dbo.Modules", new[] { "ProjectID" });
            DropIndex("dbo.Bugs", new[] { "TesterID" });
            DropIndex("dbo.Bugs", new[] { "ModuleID" });
            DropTable("dbo.Testers");
            DropTable("dbo.Logins");
            DropTable("dbo.Employees");
            DropTable("dbo.Teams");
            DropTable("dbo.Projects");
            DropTable("dbo.Developers");
            DropTable("dbo.Modules");
            DropTable("dbo.Bugs");
        }
    }
}
