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

        public List<TaskInfo> GetAllDoneUserTasks(string twitterUserId)
        {
            var result=  _sQLiteConnection.Table<TaskInfo>()
                .Where(x => x.User_Id == twitterUserId)
                .Where(x => x.Status == true).Select(x => x).ToList();

            return result;
        }

        public List<TaskInfo> GetAllNotDoneUserTasks(string twitterUserId)
        {
            var result = _sQLiteConnection.Table<TaskInfo>()
                 .Where(x => x.User_Id == twitterUserId)
                 .Where(x => x.Status == false).Select(x => x).ToList();

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

        public TaskInfo CurrentTask(int id)
        {
            return _sQLiteConnection.Table<TaskInfo>().FirstOrDefault(x => x.Id == id);
        }

    }
}
