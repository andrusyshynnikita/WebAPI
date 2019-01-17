using SQLite;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using System.Linq;
using System.Collections.Generic;


namespace TestProject.Core.services
{
    public class TaskService: ITaskService
    {
        private SQLiteConnection _sQLiteConnection;

        public TaskService(IDatabaseConnectionService databaseConnectionService)
        {
            _sQLiteConnection = databaseConnectionService.GetDatebaseConnection();
            _sQLiteConnection.CreateTable<TaskInfo>();

        }

        public List<TaskInfo> GetAllTaskData()
        {
            var result = (from data in _sQLiteConnection.Table<TaskInfo>()
                    select data).ToList();
            return result;

        }

        public List<TaskInfo> GetAllDoneUserTasks(string twitterUserId)
        {
            var result = (from data in _sQLiteConnection.Table<TaskInfo>()
                          where data.User_Id == twitterUserId 
                          where data.Status == true
                          select data).ToList();
            return result;
        }

        public List<TaskInfo> GetAllNotDoneUserTasks(string twitterUserId)
        {
            var result = (from data in _sQLiteConnection.Table<TaskInfo>()
                          where data.User_Id == twitterUserId
                          where data.Status == false
                          select data).ToList();
            return result;
        }

        public void DeleteTask(int id)
        {
            _sQLiteConnection.Delete<TaskInfo>(id);
        }

        public void InsertTask(TaskInfo taskInfo)
        {
            if (taskInfo.Id != 0)
            {
                _sQLiteConnection.Update(taskInfo);
            }

            else
            _sQLiteConnection.Insert(taskInfo);
        }

        public void DeleteAllTask()
        {

            _sQLiteConnection.DeleteAll<TaskInfo>();
        }

    }
}
