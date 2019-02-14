namespace TestProject.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "AudioFilePath", c => c.String());
            DropColumn("dbo.TaskModels", "AudioFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "AudioFile", c => c.Binary());
            DropColumn("dbo.TaskModels", "AudioFilePath");
        }
    }
}
