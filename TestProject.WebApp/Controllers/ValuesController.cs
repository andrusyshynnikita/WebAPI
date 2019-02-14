using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public async Task<string> PostTask()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                        postedFile.SaveAs(filePath);

                        //  return "/Uploads/" + fileName;
                    }
                }

                if (httpRequest["TaskModel"] != null)
                {
                    var postedForm = httpRequest.Form["TaskModel"];
                    _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);

                    _taskService.Tasks.Create(httpRequest);
                    _taskService.Save();
                }


            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return "no files";
        }

        [System.Web.Http.Route("api/Files/Upload")]
        public async Task<string> Put()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                        postedFile.SaveAs(filePath);

                        //  return "/Uploads/" + fileName;
                    }
                }

                if (httpRequest["TaskModel"] != null)
                {
                    var postedForm = httpRequest.Form["TaskModel"];
                    _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);

                    _taskService.Tasks.Update(_taskModel);
                    _taskService.Save();
                }


            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "no files";
        }
    }
}
