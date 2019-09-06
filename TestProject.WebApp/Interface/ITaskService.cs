using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Interface
{
  public  interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks(string id);
        void Create(TaskModel taskModel);
        void Update(TaskModel taskModel, byte[] audioFile, string audioFilePath);
        void Delete(int id);
        TaskModel DownloadAudioFile(int id);

    }
}
