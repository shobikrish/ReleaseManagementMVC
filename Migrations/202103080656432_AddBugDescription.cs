namespace ReleaseManagementMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBugDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "BugDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bugs", "BugDescription");
        }
    }
}
