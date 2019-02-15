using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestProject.WebApp.EF;
using TestProject.WebApp.Models;
using TestProject.WebApp.Services;

namespace TestProject.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        private TaskService _taskService;
        private TaskModel _taskModel;

        public TasksController()
        {
            _taskService = new TaskService();
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _taskService.Tasks.GetTasks(id);
            return tasks;
        }

        public void DeleteTasks(int id)
        {
            _taskService.Tasks.Delete(id);
            _taskService.Save();
        }

        [System.Web.Http.Route("api/Files/Upload")]
        public void PostTask()
        {
            var httpRequest = HttpContext.Current.Request;
            _taskService.Tasks.Create(httpRequest);
            _taskService.Save();
        }

        [System.Web.Http.Route("api/Files/Upload")]
        public void Put()
        {
           var httpRequest = HttpContext.Current.Request;

                    _taskService.Tasks.Update(httpRequest);
                    _taskService.Save();
        }

        [Route("api/DownloadFile/{id}")]
        public HttpResponseMessage GetAudioFile(int id)
        {
          var audioFile=  _taskService.Tasks.DownloadAudioFile(id);
            return audioFile;
        }
    }
}
