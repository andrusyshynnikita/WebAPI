namespace TestProject.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAudioContent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TaskModels", "AudioFileContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "AudioFileContent", c => c.Binary());
        }
    }
}
