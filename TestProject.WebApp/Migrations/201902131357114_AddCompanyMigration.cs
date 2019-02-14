namespace TestProject.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "AudioFile", c => c.Binary());
        }
        
        public override void Down()
        {
          //  DropColumn("dbo.TaskModels", "AudioFile");
        }
    }
}
