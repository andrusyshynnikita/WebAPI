using System.Collections.Generic;
using TestProject.Core.Models;

namespace TestProject.Core.Interface
{
    public interface ITaskService
    {
        List<TaskInfo> GetAllTaskData();
        List<TaskInfo> GetAllDoneUserTasks(string twitterUserId);
        List<TaskInfo> GetAllNotDoneUserTasks(string twitterUserId);
        void DeleteTask(int id);
        void InsertTask(TaskInfo taskInfo);
        void DeleteAllTask();
        TaskInfo CurrentTask(int id);

    }
}
