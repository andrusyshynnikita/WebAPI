using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Repository
{
    public class TaskRepository : ITaskRepository<TaskModel>
    {
        private TaskContext _db;
        private TaskModel _taskModel;
        private string _filename;

        public TaskRepository(TaskContext taskContext)
        {
            _db = taskContext;
        }

        public string Create(HttpRequest httpRequest)
        {
            try
            {
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        _filename = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + _filename);

                        postedFile.SaveAs(filePath);

                    }
                }

                if (httpRequest["TaskModel"] != null)
                {
                    var postedForm = httpRequest.Form["TaskModel"];
                    _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);
                    _db.Tasks.Add(_taskModel);
                }
            }

            catch (Exception exception)
            {
                return exception.Message;
            }

            return "no files";

        }

        public void Delete(int id)
        {
            TaskModel task = _db.Tasks.Find(id);
            if (task.AudioFileName != null)
            {
                var fileName = task.AudioFileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                File.Delete(filePath);
            }

            if (task != null)
            {
                _db.Tasks.Remove(task);

            }
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _db.Tasks.Where(x => x.User_Id == id).ToList();
            return tasks;
        }

        public string Update(HttpRequest httpRequest)
        {
            try
            {
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                        postedFile.SaveAs(filePath);
                    }
                }

                if (httpRequest["TaskModel"] != null)
                {
                    var postedForm = httpRequest.Form["TaskModel"];
                    _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);
                    _db.Entry(_taskModel).State = EntityState.Modified;
                }
            }

            catch (Exception exception)
            {
                return exception.Message;
            }

            return "no files";
        }

        public HttpResponseMessage DownloadAudioFile(int id)
        {
            var task = _db.Tasks.Where(x => x.Id == id).FirstOrDefault();

            var fileName = task.AudioFileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/3gpp");

            return response;
        }
    }
}