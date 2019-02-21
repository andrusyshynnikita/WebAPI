using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using TestProject.WebApp.Services;

namespace TestProject.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        private TaskService _taskService;
        private TaskModel _taskModel;
        private ITaskRepository<TaskModel> _taskRepository;

        public TasksController(ITaskRepository<TaskModel> taskRepository)
        {
            _taskService = new TaskService(taskRepository);
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _taskService.Tasks.GetTasks(id);
            return tasks;
        }

        public void DeleteTasks(int id)
        {
            _taskService.Tasks.Delete(id);
        }

        [System.Web.Http.Route("api/Files/Upload")]
        public void PostTask()
        {
            var httpRequest = HttpContext.Current.Request;
            _taskService.Tasks.Create(httpRequest);

        }

        [System.Web.Http.Route("api/Files/Upload")]
        public void Put()
        {
           var httpRequest = HttpContext.Current.Request;

                    _taskService.Tasks.Update(httpRequest);
        }

        [Route("api/DownloadFile/{id}")]
        public HttpResponseMessage GetAudioFile(int id)
        {
          var audioFile=  _taskService.Tasks.DownloadAudioFile(id);
            return audioFile;
        }
    }
}
