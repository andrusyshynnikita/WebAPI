using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Interface
{
   public interface ITaskRepository : IBaseRepository<TaskModel>
    {
        IEnumerable<TaskModel> GetAllUserTasks(string userId);
    }

}
