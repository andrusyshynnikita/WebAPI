using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.Models;

namespace TestProject.Core.Interface
{
    public interface ITaskService
    {
        List<TaskInfo> GetAllTaskData();
        void DeleteTask(int id);
        void InsertTask(TaskInfo taskInfo);

    }
}
