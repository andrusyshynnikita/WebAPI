using System;
using TestProject.WebApp.EF;
using TestProject.WebApp.Repository;

namespace TestProject.WebApp.Services
{
    public class TaskService : IDisposable
    {
        private TaskContext _db = new TaskContext();
        private TaskRepository _taskRepository;
        private bool _disposed = false;

        public TaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_db);
                }
                return _taskRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
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