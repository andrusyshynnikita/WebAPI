using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public TaskRepository(TaskContext taskContext)
        {
            _db = taskContext;
        }

        public void Create(TaskModel item)
        {
            _db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            TaskModel book = _db.Tasks.Find(id);
            if (book != null)
            {
                _db.Tasks.Remove(book);
                
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