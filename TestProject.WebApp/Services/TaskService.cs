using System;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using TestProject.WebApp.Repository;

namespace TestProject.WebApp.Services
{
    public class TaskService : IDisposable
    {
        private TaskContext _db = new TaskContext();
        private ITaskRepository<TaskModel> _taskRepository;
        private bool _disposed = false;
        public TaskService(ITaskRepository<TaskModel> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public ITaskRepository<TaskModel> Tasks
        {
            get
            {
                return _taskRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}