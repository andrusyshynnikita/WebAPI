namespace TestProject.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskModels");
        }
    }
}
