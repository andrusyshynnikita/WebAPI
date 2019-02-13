using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestProject.WebApp.EF;
using TestProject.WebApp.Models;
using TestProject.WebApp.Services;

namespace TestProject.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        TaskService _taskService;

        public TasksController()
        {
            _taskService = new TaskService();
        }
      
        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _taskService.Tasks.GetTasks(id);
            return tasks;
        }

        public void DeleteBook(int id)
        {
            _taskService.Tasks.Delete(id);
            _taskService.Save();
        }

        public bool PostTask([FromBody]TaskModel item)
        {
            _taskService.Tasks.Create(item);
            _taskService.Save();
            return true;
        }

        public void Put( [FromBody]TaskModel item)
        {
            _taskService.Tasks.Update(item);
            _taskService.Save();
        }
    }
}
