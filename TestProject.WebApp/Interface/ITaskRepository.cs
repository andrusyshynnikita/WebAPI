using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Interface
{
   public interface ITaskRepository<T> where T : class
    {
        IEnumerable<T> GetTasks(string id);
        void Create(TaskModel taskModel);
        void Update(TaskModel taskModel);
        TaskModel Delete(int id);
        TaskModel DownloadAudioFile(int id);
    }

}
