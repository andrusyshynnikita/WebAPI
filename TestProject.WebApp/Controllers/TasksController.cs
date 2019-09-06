using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Web;
using System.Web.Http;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        private ITaskService _taskService;
        private TaskModel _taskModel;
        private byte[] _audioFile;
        private string _audiofilePath;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {

            IEnumerable<TaskModel> tasks = _taskService.GetTasks(id);
            return tasks;
        }

        public void DeleteTasks(int id)
        {
            _taskService.Delete(id);
        }

        [Route("api/Files/Upload")]
        [HttpPost]
        public void PostTask(TaskModel task)
        {

            _taskService.Create(task);

        }

        [System.Web.Http.Route("api/Files/Upload")]
        public void Put()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];

                    _audiofilePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        postedFile.InputStream.CopyTo(ms);
                        _audioFile = ms.ToArray();
                    }
                }
            }

            string postedForm = httpRequest.Form["TaskModel"];

            _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);

            _taskService.Update(_taskModel, _audioFile, _audiofilePath);
        }

        [Route("api/DownloadFile/{id}")]
        public HttpResponseMessage GetAudioFile(int id)
        {
            _taskModel = _taskService.DownloadAudioFile(id);

            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + _taskModel.AudioFileName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = _taskModel.AudioFileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/3gpp");

            return response;

        }
    }
}
