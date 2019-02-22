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

        public TaskRepository()
        {
            _db = new TaskContext();
        }

        public void Create(TaskModel taskModel)
        {
            _db.Tasks.Add(taskModel);
            _db.SaveChanges();
        }

        public TaskModel Delete(int id)
        {
            TaskModel taskModel = _db.Tasks.Find(id);

            if (taskModel != null)
            {
                _db.Tasks.Remove(taskModel);
                _db.SaveChanges();
            }
            return taskModel;
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _db.Tasks.Where(x => x.User_Id == id).ToList();
            return tasks;
        }

        public void Update(TaskModel taskModel)
        {
            _db.Entry(taskModel).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public TaskModel DownloadAudioFile(int id)
        {
            TaskModel taskModel = _db.Tasks.Where(x => x.Id == id).FirstOrDefault();

            return taskModel;
        }
    }
}