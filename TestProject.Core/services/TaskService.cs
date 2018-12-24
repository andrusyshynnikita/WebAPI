using System.Collections.ObjectModel;
using SQLite;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using System.Linq;
using System;
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
            //_sQLiteConnection.Insert(new TaskInfo { TaskName = "TODO Semple", TaskDescription = "hello", TaskStatus = true });
            //_sQLiteConnection.Insert(new TaskInfo { TaskName = "TODO Semple2", TaskDescription = "hello2", TaskStatus = true });

        }



        public List<TaskInfo> GetAllTaskData()
        {
            var result = (from data in _sQLiteConnection.Table<TaskInfo>()
                    select data).ToList();
            return result;

        }

        public void DeleteTask(int id)
        {
            _sQLiteConnection.Delete<TaskInfo>(id);
        }

        public void InsertTask(TaskInfo taskInfo)
        {
            _sQLiteConnection.Insert(taskInfo);
        }

        public void DeleteAllTask()
        {
            _sQLiteConnection.DeleteAll<TaskInfo>();
        }

    }
}
