namespace TestProject.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "AudioFileName", c => c.String());
            DropColumn("dbo.TaskModels", "AudioFilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "AudioFilePath", c => c.String());
            DropColumn("dbo.TaskModels", "AudioFileName");
        }
    }
}
