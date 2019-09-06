using System.Data.Entity;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.EF
{
    public class TestProjectContext : DbContext
    {
        public TestProjectContext()
        {

        }
        public DbSet<TaskModel> Tasks { get; set; }

    }
}