using System.Data.Entity;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.EF
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

    }
}