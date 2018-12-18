using System.Collections.ObjectModel;
using SQLite;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace TestProject.Core.services
{
    public class TaskService
    {
        private SQLiteConnection _sQLiteConnection;


        public TaskService(IDatabaseConnectionService databaseConnectionService)
        {
            _sQLiteConnection = databaseConnectionService.GetDatebaseConnection();
            _sQLiteConnection.CreateTable<TaskInfo>();
            _sQLiteConnection.Insert(new TaskInfo { TaskName = "TODO Semple", TaskDescription = "hello", TaskStatus = true });
            
        }

        

        public List<TaskInfo> GetAllTaskData()
        {
             return (from data in _sQLiteConnection.Table<TaskInfo>()
                    select data).ToList();

           
        }

            public void DeleteTask(int id)
        {
            _sQLiteConnection.Delete<TaskInfo>(id);
        }

        public void InsertTask(TaskInfo taskInfo)
        {
            _sQLiteConnection.Insert(taskInfo);
        }

            
    }
}
