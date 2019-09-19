using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using TestProject.WebApp.Interface;
using TestProject.WebApp.ViewModel;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

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
        public async Task<ActionResult> DeleteTasks(int id)
        {
            ResponseViewModel result = await _taskService.Delete(id);

            if (result.IsSuccess)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "Ok");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public async Task<ActionResult> PostTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.Create(task);

            if (result.IsSuccess)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        public async Task<ActionResult> PutTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.Update(task);

            if (result.IsSuccess)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public async Task<TaskViewModel> GetAudioFile(int id)
        {
            TaskViewModel _taskModel = await _taskService.DownloadAudioFile(id);

            return _taskModel;
        }
    }
}
