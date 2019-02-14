using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
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
            if (task.AudioFilePath != null)
            {
                var fileName = task.AudioFilePath.Split('\\').LastOrDefault().Split('/').LastOrDefault();

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

        public void Update(TaskModel item)
        {
            //var oldTask = _db.Tasks.FirstOrDefault(x => x.Id == item.Id);
            //if (oldTask != null)
            //{
            //    _db.Tasks.Remove(oldTask);
            //    _db.Tasks.Add(item);
            //}
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}