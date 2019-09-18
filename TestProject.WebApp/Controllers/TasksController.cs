using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using TestProject.WebApp.ViewModel;

namespace TestProject.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskViewModel>> GetTasks(string id)
        {
            IEnumerable<TaskViewModel> tasks = await _taskService.GetTasks(id);

            return tasks;
        }

        [HttpDelete]
        public async Task<ResponseViewModel> DeleteTasks(int id)
        {
            ResponseViewModel result = await _taskService.Delete(id);

            return result;
        }

        [HttpPost]
        public async Task<ResponseViewModel> PostTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.Create(task);

            return result;
        }

        [HttpPut]
        public async Task<ResponseViewModel> PutTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.Update(task);

            return result;
        }

        [HttpGet]
        public async Task<TaskViewModel> GetAudioFile(int id)
        {
            TaskViewModel _taskModel = await _taskService.DownloadAudioFile(id);

            return _taskModel;
        }
    }
}
